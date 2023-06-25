using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateHw
{
    public class SnakeCell : Cell
    {
        public SnakeCell(int x, int y) : base(x, y)
        {
        }
        public SnakeCell(SnakeCell cell) : base(cell)
        {
        }
    }
}
