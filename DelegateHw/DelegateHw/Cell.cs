using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateHw
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Cell(Cell cell)
        {
            X = cell.X;
            Y = cell.Y;
        }
    }
}
