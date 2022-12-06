using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    internal class DayFive
    {
        /*start set
            [T] [V]                     [W]    
            [V] [C] [P] [D]             [B]    
            [J] [P] [R] [N] [B]         [Z]    
            [W] [Q] [D] [M] [T]     [L] [T]    
            [N] [J] [H] [B] [P] [T] [P] [L]    
            [R] [D] [F] [P] [R] [P] [R] [S] [G]
            [M] [W] [J] [R] [V] [B] [J] [C] [S]
            [S] [B] [B] [F] [H] [C] [B] [N] [L]
             1   2   3   4   5   6   7   8   9 
        */
        private readonly string[] _text = System.IO.File.ReadAllLines(@"C:\Users\Guti\Documents\GitHub\AdventOfCode2022\AdventSolutions\AdventSolutions\d5.txt");

        private string[] _strings = new string[] { "SMRNWJVT", "BWDJQPCV", "BJFHDRP", "FRPBMND", "HVRPTB", "CBPT", "BJRPL", "NCSLTZBW", "LSG" };
        private Stack<char>[] _stacks = new Stack<char>[9];
        private Stack<char> _bufor = new Stack<char>();

        public DayFive() {
            int i = 0;
            foreach (var _string in _strings)
            {
                _stacks[i] = new Stack<char>();
                foreach(char c in _string)
                    _stacks[i].Push(c);
                i++;
            }
        }

        public int[] PrepareData(string line)
        {
            int i = 0;
            line = line.Replace("move ", "");
            line = line.Replace("from ", "");
            line = line.Replace("to ", "");
            var values = line.Split();
            int[] data = new int[3];
            foreach(var value in values)
            {
                Int32.TryParse(value, out data[i++]);
            }
            return data;
        }

        public string Move(bool canMoveMultiple = false)
        {
            int startStack=0, finalStack=0, itemsCount=0;
            string result = "";
            foreach(string line in _text)
            {
                var data = PrepareData(line);
                itemsCount = data[0];
                startStack = data[1]-1;
                finalStack = data[2]-1;

                for(int i = 0; i < itemsCount; i++)
                {
                    if(!canMoveMultiple)
                        _stacks[finalStack].Push(_stacks[startStack].Pop());
                    else 
                        _bufor.Push(_stacks[startStack].Pop());
                }
                if(canMoveMultiple)
                    while (_bufor.Count > 0)
                        _stacks[finalStack].Push(_bufor.Pop());
            }
            foreach (var item in _stacks)
                result += item.Pop();
            return result;
        }
    }
}
