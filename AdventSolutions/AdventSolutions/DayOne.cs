using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    internal class DayOne
    {
        private readonly string[] _text = System.IO.File.ReadAllLines(@"C:\Users\Guti\Documents\GitHub\AdventOfCode2022\AdventSolutions\AdventSolutions\input.txt");
        private int _maxCalories = 0;
        private List<int> _elvesCalories = new();


        public int FindMost()
        {
            //just for being sure, butmost value should be _elvesCalories[0]
            foreach(int value in _elvesCalories)
                if (value > _maxCalories)
                    _maxCalories = value;

            return _maxCalories;
        }

        public int SumOf(int limit)
        {
            int sum = 0;
            for(int i = 0; i < limit; i++)
                sum += _elvesCalories[i];

            return sum;
        }

        public void CalculateValueForEach()
        {
            int sumOfCalories = 0;
            foreach (var line in _text)
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
                    _elvesCalories.Add(sumOfCalories);
                    sumOfCalories = 0;
                }
            }
            _elvesCalories.Sort();
            _elvesCalories.Reverse();

            //Debug Part
            foreach (int value in _elvesCalories)
                Console.WriteLine(value);
        }

    }
}
