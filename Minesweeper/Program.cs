using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(10, 10);
            b.AssignNeighbours();
            b.Show();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                string text = "";
                for (int j = 0; j < 10; j++)
                {
                    if (b.board[i,j].getIsBomb())
                    {
                        text += "1";
                    }
                    else
                    {
                        text += "0";
                    }
                }
                Console.WriteLine(text);
            }
        }
    }
}
