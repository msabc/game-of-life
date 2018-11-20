using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class Utils
    {
        public static void PrintInColor(string data, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            Console.Write(data);
            Console.ResetColor();
        }

        public static void PrintInColor(char data, ConsoleColor clr) => PrintInColor(data.ToString(), clr);
        
    }
}
