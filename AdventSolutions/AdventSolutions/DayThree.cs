using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventSolutions
{
    internal class DayThree
    {
        private readonly string[] _text = System.IO.File.ReadAllLines(@"C:\Users\Guti\Documents\GitHub\AdventOfCode2022\AdventSolutions\AdventSolutions\d3.txt");
        public int _sum=0;

        public int FindItemAndCount()
        {
            foreach(var item in _text)
            {
                //split
                int itemsCounter = item.Length / 2;
                string regex = "\\w{" + itemsCounter.ToString() + "}";
                Regex pattern = new Regex(regex);
                var match = pattern.Matches(item);

                //sort
                string compartment1 = String.Concat(match.First().ToString().OrderBy(c => c));
                string compartment2 = String.Concat(match.Last().ToString().OrderBy(c => c));

                //get type
                char itemType = '_';
                foreach(char letter in compartment1.Distinct())
                    if (compartment2.Distinct().Contains(letter))
                    {
                        itemType = letter;
                        break;
                    }
                _sum += (int)itemType - (itemType >= 97 ? 96 : 38);
            }
            return _sum;
        }

        public int FindGroupsPrioritySum()
        {
            for (int i = 0; i < _text.Length;)
            {
                string[] bags = new string[3];
                do
                {
                    bags[0] = String.Concat(_text[i++].OrderBy(c => c));
                    bags[1] = String.Concat(_text[i++].OrderBy(c => c));
                    bags[2] = String.Concat(_text[i++].OrderBy(c => c));
                } while (i % 3 != 0);

                char itemType = '_';
                foreach (char letter in bags[0].Distinct())
                {
                    if (!bags[1].Distinct().Contains(letter))
                        continue;
                    else if (bags[2].Distinct().Contains(letter))
                    {
                        itemType = letter;
                        break;
                    }
                }
                _sum += (int)itemType - (itemType >= 97 ? 96 : 38);
            }
                return _sum;
        }
    }
}
