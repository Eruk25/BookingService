using BookingService.Domain.Entities;
using BookingService.Parser.Abstractions;

namespace BookingService.Parser.Services;

public class ParserExecutor
{
    public readonly IParser Parser;

    public ParserExecutor(IParser parser)
    {
        Parser = parser;
    }

    public async Task RunAsync()
    { 
        var data = await Parser.ParseAsync();
        Console.WriteLine($"Parsed: {data.Count()} resources");
    }
}