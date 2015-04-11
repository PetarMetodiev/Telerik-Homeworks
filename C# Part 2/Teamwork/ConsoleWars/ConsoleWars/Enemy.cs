using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars
{
    public class Enemy
    {
        // Row of each enemy.
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

        // Col of each enemy.
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

        // Color of each enemy.
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

        // Symbol of each enemy.
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

        // Flag if the enemy is hit.
        private bool hit;
        public bool Hit
        {
            get
            {
                return this.hit;
            }

            set
            {
                this.hit = value;
            }
        }

        // Constructor for an enemy.
        public Enemy(int row, int col, ConsoleColor color = ConsoleColor.Gray, string symbol = "### ", bool hit = false)
        {
            Col = col;
            Row = row;
            Color = color;
            Symbol = symbol;
            Hit = hit;
        }

        //public void Destroyed()
        //{
        //    if(this.hit==true)
        //    {
        //        this.symbol = string.Empty;
        //    }
        //}
    }
}
