using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    static class Menu
    {
        public static void RunMenu()
        {
            // Menu de 3 posiciones , no permite nada mas , distintos colores para diferente aspecto
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(32, 8);
            Console.Write("1-Start new game");
            Console.SetCursorPosition(32, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2-Hall of fame");
            Console.SetCursorPosition(32, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("3-Exit");
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            // Unica variable
            var key=Console.ReadKey();

            // Hacemos el Swtch de 3 opciones
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Game.StartNewGame();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    HallOfFame.Show();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    RunMenu();
                    break;
            }


        }
    }
}
