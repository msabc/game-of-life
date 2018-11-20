using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(20, 40);

            board.Print();
            
            while (true)
            {
                Thread.Sleep(100);
                Console.Clear();
                board.NextGeneration();
                if (board.CheckForEqualBoards())
                {
                    board.InitializeBoard();
                }
                board.Print();
            }
        }
    }
}
