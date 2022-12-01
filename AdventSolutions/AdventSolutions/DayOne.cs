using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    internal class DayOne
    {
        private string[] _text = System.IO.File.ReadAllLines(@"C:\Users\Guti\Documents\GitHub\AdventOfCode2022\AdventSolutions\AdventSolutions\input.txt");
        private int maxCalories = 0;


        public int CalculateMostValue()
        {
            int sumOfCalories = 0;

            foreach(var line in _text)
            {
                if (line != "")
                {
                    try
                    {
                        sumOfCalories += Int32.Parse(line);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Unable to parse '{line}'");
                    }
                }
                else
                {
                    if (sumOfCalories > maxCalories)
                        maxCalories = sumOfCalories;
                    sumOfCalories = 0;
                }
            }

            return maxCalories;
        }
    }
}
