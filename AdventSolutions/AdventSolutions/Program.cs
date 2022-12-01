// See https://aka.ms/new-console-template for more information
using AdventSolutions;

Console.WriteLine("Hello, World!");
DayOne dayOne = new DayOne();
dayOne.CalculateValueForEach();
Console.WriteLine($"Max: {dayOne.FindMost()}\n" +
    $"Top 3 sum: {dayOne.SumOf(3)}");