using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Board
    {
        private bool[][] board;
        private const char AliveChar = '*';
        private const char DeadChar = '-';
        private const ConsoleColor AliveColor = ConsoleColor.Green;
        private const ConsoleColor DeadColor = ConsoleColor.Red;
        private Random rng = new Random();

        private int rows;
        private int cols;

        public Board(int rows, int cols)
        {
            board = new bool[rows][];
            this.rows = rows;
            this.cols = cols;

            for (int i = 0; i < rows; i++)
            {
                board[i] = new bool[cols];
            }

            InitializeBoard();
        }

        public void InitializeBoard()
        {
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // 20% chance a cell would be alive
                    board[i][j] = rng.Next(5) == 1;
                }
            }
        }

        private List<bool> GetNeighbours(int row,int col)
        {
            List<bool> neighbours = new List<bool>();

            for (int i = col-1; i <= col+1; i++)
            {
                for (int j = row-1; j <= row+1; j++)
                {
                    if (!(i == col && j == row))
                    {
                        if (IndexValid(i,j))
                        {
                            neighbours.Add(GetCharAt(i,j));
                        }
                    }
                }
            }
            return neighbours;
        }

        private bool IndexValid(int row, int col) => row >= 0 && row < board.Length && col >= 0 && col < board[0].Length;

        public void Print()
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (GetCharAt(i,j))
                    {
                        Utils.PrintInColor(AliveChar, AliveColor);
                    }
                    else
                    {
                        Utils.PrintInColor(DeadChar, DeadColor);
                    }

                }
                Console.WriteLine();
            }
        }

        private bool[][] currentGeneration;

        public void NextGeneration()
        {
            currentGeneration = new bool[rows][];

            for (int i = 0; i < rows; i++)
            {
                currentGeneration[i] = new bool[cols];
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var liveNeighbours = GetNeighbours(i, j).Where(n => n == true).Count();

                    // if alive
                    if (GetCharAt(i, j))
                    {
                        if (liveNeighbours < 2 || liveNeighbours > 3)
                        {
                            board[i][j] = false;
                        }
                    }
                    // if dead
                    else
                    {
                        if (liveNeighbours == 3)
                        {
                            board[i][j] = true;
                        }
                    }
                    currentGeneration[i][j] = board[i][j];
                }
            }
        }
        

        public bool CheckForEqualBoards()
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (currentGeneration[i][j] != board[i][j])
                    {
                        return false;
                    }
                    
                }
            }

            return true;
        }
        
        private bool GetCharAt(int row,int col)
        {
            return board[row][col];
        }

        private void SetCharAt(int row,int col, bool alive)
        {
            board[row][col] = alive;
        }
    }


}
