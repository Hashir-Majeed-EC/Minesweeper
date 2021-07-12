using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game(10, 10);
            g.PlayGame();
        }
    }
}
