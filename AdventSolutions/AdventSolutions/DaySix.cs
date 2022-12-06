using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    internal class DaySix
    {
        private readonly string _text = System.IO.File.ReadAllText(@"C:\Users\Guti\Documents\GitHub\AdventOfCode2022\AdventSolutions\AdventSolutions\d6.txt");
        private int _markerSpot;
        public int findMarker(int size)
        {
            for(int i = 0; i < _text.Length-size; i++)
            {
                var chars = _text.Substring(i, size).Distinct();
                if (chars.Count() == size)
                {
                    _markerSpot = i+size;
                    break;
                }
            }
            return _markerSpot;
        }
    }
}
