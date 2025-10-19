using System;
using System.Globalization;
using AngleSharp;
using AngleSharp.Dom;
using BookingService.Domain.Entities;
using BookingService.Parser.Implementations;
using BookingService.Parser.Services;

namespace BookingService.Parser
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            ParserExecutor executor = new ParserExecutor(new KufarParser());
            await executor.RunAsync();
        }
    }    
}       