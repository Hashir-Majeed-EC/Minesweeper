using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Cell
    {
        private bool isBomb;
        private int value;
        public Cell(bool isBomb)
        {
            value = 0;
            this.isBomb = isBomb;
        }

        public int getValue()
        {
            return value;
        }

        public void setValue(int value)
        {
            this.value = value;
        }

        public bool getIsBomb()
        {
            return isBomb;
        }
    }
}
