using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    static class Logo
    {
        public static void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n");
            Console.WriteLine(@"
                                .-------------------.  
                                | .--------------. ||
                                | | ____    ____ | ||
                                | ||_   \  /   _|| ||
                                | |  |   \/   |  | ||
                                | |  | |\  /| |  | || Mirkito Gonzalez
                                | | _| |_\/_| |_ | ||
                                | ||_____||_____|| ||
                                | |              | ||
                                | '--------------' ||
                                '-------------------'  ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine(@"     
 /$$$$$$$                                                      /$$              
| $$__  $$                                                    | $$              
| $$  \ $$  /$$$$$$   /$$$$$$   /$$$$$$$  /$$$$$$  /$$$$$$$  /$$$$$$    /$$$$$$$
| $$$$$$$/ /$$__  $$ /$$__  $$ /$$_____/ /$$__  $$| $$__  $$|_  $$_/   /$$_____/
| $$____/ | $$  \__/| $$$$$$$$|  $$$$$$ | $$$$$$$$| $$  \ $$  | $$    |  $$$$$$ 
| $$      | $$      | $$_____/ \____  $$| $$_____/| $$  | $$  | $$ /$$ \____  $$
| $$      | $$      |  $$$$$$$ /$$$$$$$/|  $$$$$$$| $$  | $$  |  $$$$/ /$$$$$$$/
|__/      |__/       \_______/|_______/  \_______/|__/  |__/   \___/  |_______/ ");
            Console.WriteLine("\n");
            Console.ForegroundColor=ConsoleColor.Green;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("                                T H E   S N A K E");
        }
    }
}
