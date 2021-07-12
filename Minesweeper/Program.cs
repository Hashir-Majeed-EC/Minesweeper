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
            b.Move(1, 1);
            b.Show();
            Console.WriteLine(b.board[1, 1].getIsBomb());
            b.ShowAll();
        }
    }
}
