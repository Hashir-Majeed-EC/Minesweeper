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

            ComputeCentres(dict);
            ComputeEdgeRows(dict);
            ComputeCorners(dict);          
        }

        private void ComputeCorners(Dictionary<bool, int> dict)
        {
            board[0, 0].setValue(dict[board[0, 1].getIsBomb()] + dict[board[1, 0].getIsBomb()] + dict[board[1, 1].getIsBomb()]);
            board[board.GetLength(0) - 1, 0].setValue(dict[board[board.GetLength(0) - 1, 1].getIsBomb()] + dict[board[board.GetLength(0) - 2, 0].getIsBomb()] + dict[board[board.GetLength(0) - 2, 1].getIsBomb()]);
            board[0, board.GetLength(1) - 1].setValue(dict[board[1, board.GetLength(1) - 1].getIsBomb()] + dict[board[0, board.GetLength(1) - 2].getIsBomb()] + dict[board[1, board.GetLength(1) - 2].getIsBomb()]);
            board[board.GetLength(0) - 1, board.GetLength(1) - 1].setValue(dict[board[board.GetLength(0) - 2, board.GetLength(1) - 1].getIsBomb()] + dict[board[board.GetLength(0) - 1, board.GetLength(1) - 2].getIsBomb()] + dict[board[board.GetLength(0) - 2, board.GetLength(1) - 2].getIsBomb()]);
        }

        private void ComputeEdgeRows(Dictionary<bool,int> dict)
        {
            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                board[i, 0].setValue(dict[board[i - 1, 0].getIsBomb()] + dict[board[i + 1, 0].getIsBomb()] + dict[board[i - 1, 1].getIsBomb()] + dict[board[i, 1].getIsBomb()] + dict[board[i + 1, 1].getIsBomb()]);
            }

            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                board[0, i].setValue(dict[board[0, i - 1].getIsBomb()] + dict[board[0, i + 1].getIsBomb()] + dict[board[1, i - 1].getIsBomb()] + dict[board[1, i].getIsBomb()] + dict[board[1, i + 1].getIsBomb()]);
            }

            for (int i = 1; i < board.GetLength(1) - 1; i++)
            {
                board[i, board.GetLength(1) - 1].setValue(dict[board[i - 1, board.GetLength(1) - 1].getIsBomb()] + dict[board[i + 1, board.GetLength(1) - 1].getIsBomb()] + dict[board[i - 1, board.GetLength(1) - 2].getIsBomb()] + dict[board[i, board.GetLength(1) - 2].getIsBomb()] + dict[board[i + 1, board.GetLength(1) - 2].getIsBomb()]);
            }

            for (int i = 1; i < board.GetLength(1) - 1; i++)
            {
                board[board.GetLength(0) - 1, i].setValue(dict[board[board.GetLength(0) - 1, i - 1].getIsBomb()] + dict[board[board.GetLength(0) - 1, i + 1].getIsBomb()] + dict[board[board.GetLength(0) - 2, i - 1].getIsBomb()] + dict[board[board.GetLength(0) - 2, i].getIsBomb()] + dict[board[board.GetLength(0) - 2, i + 1].getIsBomb()]);
            }
        }

        private void ComputeCentres(Dictionary<bool, int> dict)
        {
            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < board.GetLength(1) - 1; j++)
                {
                    board[i, j].setValue(dict[board[i - 1, j - 1].getIsBomb()] + dict[board[i - 1, j].getIsBomb()] + dict[board[i - 1, j + 1].getIsBomb()] + dict[board[i, j - 1].getIsBomb()] + dict[board[i, j + 1].getIsBomb()] + dict[board[i + 1, j - 1].getIsBomb()] + dict[board[i + 1, j].getIsBomb()] + dict[board[i + 1, j + 1].getIsBomb()]);
                }
            }
        }

        public int Move(int x, int y)
        {
            //0 is invalid move
            //1 is bomb
            // 2 is move or floodfill move
            int result = 0;

            if (board[x, y].getIsBomb())
            {
                return 1;
            }

            if (board[x,y].getValue() != 0)
            {
                board[x, y].setIsShown(true);
                return 2;
            }
              

            if (board[x,y].getIsShown() == false)
            {
                return dfs(x,y);
            }
            return result;
        }

        private int dfs(int x, int y)
        {
            if ((x < 0 || x >= board.GetLength(0) || y < 0 || y >= board.GetLength(1) || board[x, y].getIsShown() || board[x,y].getIsBomb() || board[x,y].getValue() != 0))
            {
                return 2;
            }
            else
            {
                board[x, y].setIsShown(true);
                dfs(x + 1, y);
                dfs(x - 1, y);
                dfs(x, y + 1);
                dfs(x, y - 1);
            }
            return 2;
        }
        public void Show()
        {
            string text = "";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (!board[i, j].getIsShown())
                    {
                        text += "*";
                    }
                    else
                    {
                        if (board[i, j].getIsBomb())
                        {
                            text += "+";
                        }
                        else
                        {
                            text += board[i, j].getValue().ToString();
                        }
                    }
                    
                }
                Console.WriteLine(text);
                text = "";
            }
        }

        public void ShowAll()
        {
            string text = "";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].getIsBomb())
                    {
                        text += "+";
                    }
                    else
                    {
                        text += board[i, j].getValue().ToString();
                    }                
                }
                Console.WriteLine(text);
                text = "";
            }
        }

    }
}
