using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Web;
using AngleSharp;
using AngleSharp.Dom;
using BookingService.Domain.Entities;
using BookingService.Parser.Abstractions;

namespace BookingService.Parser.Implementations;

public class KufarParser : IParser
{
    private readonly IBrowsingContext _context;
    public KufarParser()
    {
        _context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
    }
    public async Task<IDocument?> GetDocumentAsync(string? link = "start")
    {
        UriBuilder uriBuilder = new UriBuilder
        {
            Scheme = "https",
            Host = "re.kufar.by",
            Path = "/l/belarus/snyat/kvartiru",
            Query = link == "start"
            ? "cur=USD&size=30"
            : $"cur=USD&size=30&cursor={link}"

        };
        string fullUrl = uriBuilder.Uri.ToString();
        IDocument? document = await _context.OpenAsync(fullUrl);
        return document;
    }

    public IEnumerable<string> GetPaginationLinks(IDocument document)
    {
        var paginationLinks = document.All
            .Where(el => 
            el.LocalName == "a" && el.ClassList.Contains("styles_link__8m3I9"));
        var paths = paginationLinks
            .Select(el => el.GetAttribute("href"))
            .Where(el => el != null);
        HashSet<string> cursorQueries = new HashSet<string>();
        foreach (var path in paths)
        {
            var queries= HttpUtility.ParseQueryString(path); 
            cursorQueries.Add(queries["cursor"] ?? string.Empty);
        }
        return cursorQueries;
    }

    public IEnumerable<IElement>? GetCards(IDocument document)
    {
        var cards = document.All.Where(el =>
            el.LocalName == "a" && el.ClassList.Contains("styles_wrapper__Q06m9"));
        return cards;
    }

    public Resource? ParseCard(IElement card)
    {
        var priceRaw = card.QuerySelector(".styles_price__byr__lLSfd")?.TextContent.Trim();
        decimal? price = null;
        if (priceRaw == "Договорная") 
            return null;
        if (!string.IsNullOrWhiteSpace(priceRaw)) 
        {
            var cleaned = priceRaw.Replace(" р. / мес.", "").Replace(" ", "").Trim();
            if (decimal.TryParse(cleaned, out var priceDecimal)) 
                price = priceDecimal;
        }
                
        var titleEl = card.QuerySelector(".styles_parameters__7zKlL")?.TextContent.Trim(); 
        var addressEl = card.QuerySelector(".styles_address__l6Qe_")?.TextContent.Trim(); 
        var descEl = card.QuerySelector(".styles_body__5BrnC")?.TextContent;
        var imgEl = card.QuerySelector(".styles_image__ZPJzx")?.GetAttribute("src")?.Trim();
        var href = card.GetAttribute("href")?.Trim();
        if (href == null) return null;
        var url = new Uri(href, UriKind.RelativeOrAbsolute);
        var sourceId = url.AbsolutePath.Split('/').LastOrDefault() ?? "-";
        return new Resource(
            titleEl ?? "-",
            descEl ?? "-",
            addressEl ?? "-",
            price ?? 0,
            imgEl ?? "-",
            sourceId);
    }

    public async Task<IEnumerable<Resource>> ParseAsync()
    {
        var resources = new List<Resource>();
        Queue<string?> queue = new Queue<string?>();
        HashSet<int?> visited = new HashSet<int?>();
        queue.Enqueue("start");
        visited.Add(1);
        while (queue.Count > 0)
        {
            var link = queue.Dequeue();
            var document = await GetDocumentAsync(link);
            if(document == null) continue;
            var links = GetPaginationLinks(document); 
            foreach (var newLink in links) 
            {
                var page = NormalizeCursorQuery(newLink);
                if(page == null) continue;
                if (visited.Add(page)) 
                {
                    queue.Enqueue(newLink);
                }
            }
            var cards = GetCards(document);
            if(cards is null) continue;
            foreach (var card in cards)
            {
                var resource = ParseCard(card);
                if(resource != null)
                    resources.Add(resource);
            }
        }
        return resources;
    }

    public int? NormalizeCursorQuery(string? cursor = null)
    {
        if (cursor != null)
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(cursor));
            var obj = JsonDocument.Parse(json);
            var page = obj.RootElement.TryGetProperty("p", out var value) ? value.GetInt32() : -1;
            return page;
        }
        return null;
    }
}