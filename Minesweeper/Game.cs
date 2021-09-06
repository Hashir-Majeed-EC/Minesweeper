using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Game
    {
        private Board b;
        private bool inPlay;
        
        public Game(int x, int y)
        {
            b = new Board(x, y);
            b.AssignNeighbours();
            inPlay = true;
        }

        public void PlayGame()
        {

            int x;
            int y;
            int result;

            while (inPlay)
            {
                b.Show();
                Console.WriteLine("Enter x position: ");
                x = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter y position: ");
                y = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                result = b.Move(y, x);
                if (b.CheckWin())
                {
                    Console.WriteLine("You win!");
                    inPlay = false;
                }
                if (result == 1)
                {
                    Console.WriteLine("BOMB HIT! YOU LOSE :)");
                    inPlay = false;
                    b.ShowAll();
                }

                if (result == 0)
                {
                    Console.WriteLine("Invalid Move");
                }
                
            }
        }
    }
}
