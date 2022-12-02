using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    internal class DayTwo
    {
        private readonly string[] _text = System.IO.File.ReadAllLines(@"C:\Users\Guti\Documents\GitHub\AdventOfCode2022\AdventSolutions\AdventSolutions\d2.txt");

        public int Play() {
            int score = 0;
            string player;
            string oponent;

            foreach(var line in _text)
            {
                player = line.Split(" ")[1];
                oponent= line.Split(" ")[0];

                switch(player)
                {
                    case "X":// A - draw    B - los     C - win
                        score += 1;
                        score += oponent.Equals("C") ? 6 : oponent.Equals("A") ? 3 : 0;
                        break; 
                    case "Y":// A - win    B - draw     C - los
                        score += 2;
                        score += oponent.Equals("A") ? 6 : oponent.Equals("B") ? 3 : 0;
                        break; 
                    case "Z":// A - los    B - win     C - draw
                        score += 3;
                        score += oponent.Equals("B") ? 6 : oponent.Equals("C") ? 3 : 0;
                        break;
                }
            }
            return score; 
        }
        public int NewRules()
        {
            int score = 0;
            string player;
            string oponent;

            foreach (var line in _text)
            {
                player = line.Split(" ")[1];
                oponent = line.Split(" ")[0];

                switch (player)
                {
                    case "X"://we need to lose so no point
                        //if oponent choose Rock +3forScissors, if choose Scissors +2forPaper, if choose Paper +1forRock
                        score += oponent.Equals("A") ? 3 : oponent.Equals("C") ? 2 : 1;
                        break;
                    case "Y":
                        score += 3;
                        score += oponent.Equals("C") ? 3 : oponent.Equals("B") ? 2 : 1;
                        break;
                    case "Z":
                        score += 6;
                        score += oponent.Equals("B") ? 3 : oponent.Equals("A") ? 2 : 1;
                        break;
                }
            }
            return score;
        }

    }
}
