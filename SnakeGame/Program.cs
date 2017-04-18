using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.SetWindowSize(80, 26);
            Console.CursorVisible = false;
            Logo.Draw();
            Console.ReadKey();
            Menu.RunMenu();
        }
    }
}
