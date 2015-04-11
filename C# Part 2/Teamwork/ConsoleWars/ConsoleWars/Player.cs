using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars
{
    public class Player
    {
        // Col of the player. Petar.
        private int col;
        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                this.col = value;
            }
        }

        // Row of the player. Petar.
        private int row;
        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        // Color of the player. Petar.
        private ConsoleColor color;
        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        // Symbol of the player. Petar.
        private string symbol;
        public string Symbol
        {
            get
            {
                return this.symbol;
            }

            set
            {
                this.symbol = value;
            }
        }
        // Constructor for the player.
        public Player(int col, int row, ConsoleColor color, string symbol)
        {
            Col = col;
            Row = row;
            Color = color;
            Symbol = symbol;
        }
    }
}
