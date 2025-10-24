using System.Net.Http.Json;
using BookingService.Domain.Entities;
using BookingService.Parser.Abstractions;

namespace BookingService.Parser.Services;

public class ParserExecutor
{
    public readonly IParser Parser;
    private readonly HttpClient _httpClient;

    public ParserExecutor(IParser parser)
    {
        Parser = parser;
        _httpClient = new HttpClient();
    }

    public async Task RunAsync()
    { 
        var data = await Parser.ParseAsync();
        using var response = await _httpClient.PostAsJsonAsync("http://localhost:5091/api/Resources/import", data);
        Console.WriteLine(response.StatusCode);
    }
}