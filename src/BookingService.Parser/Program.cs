using System;
using System.Globalization;
using AngleSharp;
using AngleSharp.Dom;
using BookingService.Domain.Entities;
using BookingService.Parser.Implementations;

namespace BookingService.Parser
{
    static class Program
    {
        static async Task Main(string[] args)
        {
           KufarParser parser = new KufarParser();
           var resources = await parser.ParseAsync();
        }
    }    
}       