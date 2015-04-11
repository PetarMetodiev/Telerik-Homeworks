using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars
{
    class Bullet
    {
        public int Col { get; set; }
        public int Row { get; set; }
        public bool visible = false;

        public Bullet(int col, int row, string symbol="!")
        {
            this.Row = row;
            this.Col = col;
        }

        public void ChangePosition()
        {
            this.Row--;
        }
    }
}
