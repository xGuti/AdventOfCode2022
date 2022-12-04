using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    internal class DayFour
    {
        private readonly string[] _text = System.IO.File.ReadAllLines(@"C:\Users\Guti\Documents\GitHub\AdventOfCode2022\AdventSolutions\AdventSolutions\d4.txt");
        private int _recurringRanges = 0;
        public class Elf
        {
            int _lowerIndex;
            public int LowerIndex { get { return _lowerIndex;} }
            int _upperIndex;
            public int UpperIndex { get { return _upperIndex;} }
            public Elf(int lowerIndex, int upperIndex)
            {
                _lowerIndex = lowerIndex;
                _upperIndex = upperIndex;
            }
        }

        public Elf[] PrepareData(string data)
        {
            string[] strings = data.Split(',');
            Elf[] elf = new Elf[2];
            elf[0] = new Elf(Int32.Parse(strings[0].Split('-')[0]), Int32.Parse(strings[0].Split('-')[1]));
            elf[1] = new Elf(Int32.Parse(strings[1].Split('-')[0]), Int32.Parse(strings[1].Split('-')[1]));
            return elf;
        }

        public int CountRecurringRanges()
        {
            foreach(string line in _text)
            {
                Elf[] elf = PrepareData(line);
                if ( (elf[0].LowerIndex <= elf[1].LowerIndex &&
                     elf[0].UpperIndex >= elf[1].UpperIndex ) ||
                     (elf[1].LowerIndex <= elf[0].LowerIndex &&
                     elf[1].UpperIndex >= elf[0].UpperIndex) )
                    _recurringRanges++;
            }
            return _recurringRanges;
        }

        public int CountOverlaps()
        {
            foreach (string line in _text)
            {
                Elf[] elf = PrepareData(line);
                if ((elf[0].LowerIndex <= elf[1].LowerIndex && elf[1].LowerIndex <= elf[0].UpperIndex) ||
                    (elf[0].UpperIndex >= elf[1].UpperIndex && elf[1].UpperIndex >= elf[0].LowerIndex) ||
                    (elf[1].LowerIndex <= elf[0].LowerIndex && elf[0].LowerIndex <= elf[1].UpperIndex) ||
                    (elf[1].UpperIndex >= elf[0].UpperIndex && elf[0].UpperIndex >= elf[1].LowerIndex) )
                    _recurringRanges++;
            }
            return _recurringRanges;
        }
    }
}
