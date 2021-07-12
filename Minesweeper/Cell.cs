using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Cell
    {
        private bool isBomb;
        private int value;
        private bool shown;
        public Cell(bool isBomb)
        {
            value = 0;
            this.isBomb = isBomb;
            shown = false;
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

        public bool getIsShown()
        {
            return shown;
        }

        public void setIsShown(bool x)
        {
            shown = x;
        }
    }
}
