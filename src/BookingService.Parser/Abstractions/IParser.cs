using AngleSharp.Dom;
using BookingService.Domain.Entities;

namespace BookingService.Parser.Abstractions;

public interface IParser
{
    public Task<IDocument?> GetDocumentAsync(string? link = null);
    public IEnumerable<string> GetPaginationLinks(IDocument document);
    public IEnumerable<IElement>? GetCards(IDocument document);
    public Task<IEnumerable<Resource>> ParseAsync();
    public Resource? ParseCard(IElement card);
    public int? NormalizeCursorQuery(string? cursor = null);
}