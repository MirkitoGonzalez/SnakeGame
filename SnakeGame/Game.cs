using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    static class Game
    {
        static bool inGame = true;
        static DateTime start = DateTime.Now;
        static Food food = new Food();
        static int score = 0;
        public static void StartNewGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            inGame = true;
            score = 0;
            Snake.Make();
            MakePlayground();
            food.Appear();
            Play();
        }

        private static void Play()
        {
            while (inGame)
            {
                CheckForInput();
                ResetFood();
                CheckForSelfColision();
                Move();
                IsFoodEaten();
                Thread.Sleep(100);
            }
        }

        private static void CheckForSelfColision()
        {
            if (Snake.CheckForSelfColission())
            {
                GameOver();
            }
        }

        private static void IsFoodEaten()
        {
            if (Snake.CheckColission(food.X, food.Y))
            {
                if (food.View == 0)
                {
                    Snake.ClearSnake();
                    Snake.Make();
                }
                else
                {
                    score += food.View;
                    Snake.Grow();
                    Console.SetCursorPosition(1, 24);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Score = {0}", score);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                food = new Food();
                food.Appear();

            }
        }

        private static void ResetFood()
        {
            if (start <= DateTime.Now.Subtract(TimeSpan.FromSeconds(10)))
            {
                food.Disappear();
                start = DateTime.Now;
                food = new Food();
                food.Appear();
            }
        }

        private static void MakePlayground()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int x = 1; x < 79; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.WriteLine("=");
                Console.SetCursorPosition(x, 23);
                Console.WriteLine("=");
            }
            for (int i = 1; i < 23; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("|");
                Console.SetCursorPosition(79, i);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(1, 24);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Score = {0}", score);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Move()
        {
            bool on = Snake.Move();
            if (!on)
            {
                GameOver();
            }
        }

        private static void GameOver()
        {
            inGame = false;
            Console.SetCursorPosition(35, 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Snake.ClearSnake();
            CheckResultInHallOfFame();
            Menu.RunMenu();
        }

        private static void CheckResultInHallOfFame()
        {
            if (HallOfFame.CheckForFameResult(score))
            {
                Console.Clear();
                Console.SetCursorPosition(18, 9);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("So You've got a great result! Congratulations!!!");
                Console.SetCursorPosition(18, 13);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Please, enter your name without spaces: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = true;
                string name = Console.ReadLine();
                Console.CursorVisible = false;
                HallOfFameEntry entry = new HallOfFameEntry();
                if (name.Contains(' '))
                {
                    string[] res = name.Trim().Split();
                    name = res[0];
                }
                entry.Name = name;
                entry.Score = score;
                HallOfFame.EnterHallOfFame(entry);
            }
        }

        private static void CheckForInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (Snake.direction != Direction.right)
                    {
                        Snake.direction = Direction.left;
                    }

                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (Snake.direction != Direction.left)
                    {
                        Snake.direction = Direction.right;
                    }

                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (Snake.direction != Direction.down)
                    {
                        Snake.direction = Direction.up;
                    }

                }
                if (key.Key == ConsoleKey.DownArrow && Snake.direction != Direction.up)
                {
                    Snake.direction = Direction.down;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    inGame = false;
                }
            }
        }
    }
}
