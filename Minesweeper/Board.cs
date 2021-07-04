using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Board
    {
        public Cell[,] board;
        public Board(int x, int y)
        {
            board = new Cell[x, y];
            var random = new Random();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    board[i, j] = new Cell(random.Next(10) == 1);
                }
            }
        }

        public void AssignNeighbours()
        {
            
            Dictionary<bool, int> dict= new Dictionary<bool, int>
            {
                { true, 1 },
                { false, 0 }
            };

            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < board.GetLength(1) - 1; j++)
                {
                    board[i, j].setValue(dict[board[i - 1, j - 1].getIsBomb()] + dict[board[i - 1, j].getIsBomb()] + dict[board[i - 1, j + 1].getIsBomb()] + dict[board[i, j - 1].getIsBomb()] + dict[board[i, j + 1].getIsBomb()] + dict[board[i + 1, j - 1].getIsBomb()] + dict[board[i + 1, j].getIsBomb()] + dict[board[i + 1, j + 1].getIsBomb()]);
                }
            }

            board[0, 0].setValue(dict[board[0, 1].getIsBomb()] + dict[board[1, 0].getIsBomb()] + dict[board[1, 1].getIsBomb()]);
            board[board.GetLength(0) - 1, 0].setValue(dict[board[board.GetLength(0) - 1, 1].getIsBomb()] + dict[board[board.GetLength(0) - 2, 0].getIsBomb()] + dict[board[board.GetLength(0) - 2, 1].getIsBomb()]);
            board[0, board.GetLength(1) - 1].setValue(dict[board[1, board.GetLength(1) - 1].getIsBomb()] + dict[board[0, board.GetLength(1) - 2].getIsBomb()] + dict[board[1 , board.GetLength(1) - 2].getIsBomb()]);
            board[board.GetLength(0) - 1, board.GetLength(1) - 1].setValue(dict[board[board.GetLength(0)-2, board.GetLength(1) - 1].getIsBomb()] + dict[board[board.GetLength(0) - 1, board.GetLength(1) - 2].getIsBomb()] + dict[board[board.GetLength(0) - 2, board.GetLength(1) - 2].getIsBomb()]);

            for (int i = 1; i < board.GetLength(0)-1; i++)
            {
                board[i, 0].setValue(dict[board[i - 1, 0].getIsBomb()] + dict[board[i + 1, 0].getIsBomb()] + dict[board[i - 1, 1].getIsBomb()] + dict[board[i, 1].getIsBomb()] + dict[board[i + 1, 1].getIsBomb()]);
            }

            for (int i = 1; i < board.GetLength(0)-1; i++)
            {
                board[0, i].setValue(dict[board[0, i-1].getIsBomb()] + dict[board[0, i+1].getIsBomb()] + dict[board[1, i-1].getIsBomb()] + dict[board[1, i].getIsBomb()] + dict[board[1,i + 1].getIsBomb()]);
            }

            for (int i = 1; i < board.GetLength(1)-1; i++)
            {
                board[i, board.GetLength(1)-1].setValue(dict[board[i - 1, board.GetLength(1)-1].getIsBomb()] + dict[board[i + 1, board.GetLength(1)-1].getIsBomb()] + dict[board[i - 1, board.GetLength(1)-2].getIsBomb()] + dict[board[i, board.GetLength(1)-2].getIsBomb()] + dict[board[i + 1, board.GetLength(1)-2].getIsBomb()]);
            }

            for (int i = 1; i < board.GetLength(1) - 1; i++)
            {
                board[board.GetLength(0)-1, i].setValue(dict[board[board.GetLength(0) - 1, i - 1].getIsBomb()] + dict[board[board.GetLength(0)-1, i+1].getIsBomb()] + dict[board[board.GetLength(0) - 2, i-1].getIsBomb()] + dict[board[board.GetLength(0) - 2, i].getIsBomb()] + dict[board[board.GetLength(0) - 2, i + 1].getIsBomb()]);
            }
        }

        public void Show()
        {
            string text = "";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    text += board[i, j].getValue().ToString();
                }
                Console.WriteLine(text);
                text = "";
            }
        }

    }
}
