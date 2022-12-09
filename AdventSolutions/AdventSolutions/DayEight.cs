using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    internal class DayEight
    {
        private static readonly string[] _text = System.IO.File.ReadAllLines(@"C:\Users\Guti\Documents\GitHub\AdventOfCode2022\AdventSolutions\AdventSolutions\d8.txt");
        private static int _rows = _text.Length;
        private static int _columns = _text[0].Length;
        
        private readonly int[,] _matrix = new int[_rows, _columns];
        private int visibleCount = 2 * _rows + 2 * _columns - 4;
        
        public DayEight() { 
            for(int i = 0; i < _text.Length; i++)
                for(int j = 0; j < _text[i].Length; j++)
                    int.TryParse(_text[i][j].ToString(), out _matrix[i,j]);
        }
        private bool CheckVisibilityOnSide(bool vertical, int treeRow, int treeColumn, int start, int end)
        {
            var tree = _matrix[treeRow, treeColumn];
            for (int i = start; i < end; i++)
            {
                if (vertical)
                {
                    if (_matrix[treeRow, i] >= tree)
                        return false;
                }
                else
                {
                    if (_matrix[i, treeColumn] >= tree)
                        return false;
                }
            }
            return true;
        }
        private bool CheckVisibility(int row, int column)
        {
            var visibleLeft = CheckVisibilityOnSide(true, row, column, 0, column);
            var visibleRight = CheckVisibilityOnSide(true, row, column, column + 1, _columns);
            var visibleTop = CheckVisibilityOnSide(false, row, column, 0, row);
            var visibleBot = CheckVisibilityOnSide(false, row, column, row + 1, _rows);

            var visibility = visibleLeft || visibleRight || visibleTop || visibleBot;
            return visibility;
        }

        public int CountVisible()
        {
            for(int i=1; i<_rows-1; i++)
                for(int j=1; j<_columns-1; j++)
                    if(CheckVisibility(i, j)) visibleCount++;

            return visibleCount;
        }

        public int CountScenicScore(int i, int j)
        {
            int score = 1;

            var home = _matrix[i, j];
                    var tree = 0;
                    var step = 1;
                    do
                    {
                        tree = _matrix[i, j - step];
                        step++;
                    } while (tree < home && step <= j);
                    score *= step;

                    step = 1;
                    do
                    {
                        tree = _matrix[i, j + step];
                        step++;
                    } while (tree < home && step + j <= _columns);
                    score *= step;

                    step = 1;
                    do
                    {
                        tree = _matrix[i - step, j];
                        step++;
                    } while (tree < home);
                    score *= step;

                    step = 1;
                    do
                    {
                        tree = _matrix[i+step, j];
                        step++;
                    } while (tree < home);
            score *= step;

                
            return score;
        }
    }
}
