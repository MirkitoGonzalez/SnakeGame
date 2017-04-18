using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    static class Snake
    {
        private static List<Part> snake = new List<Part>();
        public static Direction direction;
        public static void Make()
        {
            for (int i = 1; i < 6; i++)
            {
                Part part = new Part();
                part.X = i;
                part.Y = 5;
                snake.Add(part);
            }
            direction = Direction.right;
            DrawSnake();
            
        }
        public static void Right()
        {
            ClearPart(snake[0]);
            snake.RemoveAt(0);
            Part part = new Part();
            part.Y = snake[snake.Count - 1].Y;
            part.X = snake[snake.Count - 1].X+1;
            snake.Add(part);
            DrawPart(part);
        }
        public static void Left()
        {
            ClearPart(snake[0]);
            snake.RemoveAt(0);
            Part part = new Part();
            part.Y = snake[snake.Count - 1].Y;
            part.X = snake[snake.Count - 1].X - 1;
            snake.Add(part);
            DrawPart(part);
        }
        public static void Up()
        {
            ClearPart(snake[0]);
            snake.RemoveAt(0);
            Part part = new Part();
            part.Y = snake[snake.Count - 1].Y-1;
            part.X = snake[snake.Count - 1].X;
            snake.Add(part);
            DrawPart(part);
        }
        public static void Down()
        {
            ClearPart(snake[0]);
            snake.RemoveAt(0);
            Part part = new Part();
            part.Y = snake[snake.Count - 1].Y+1;
            part.X = snake[snake.Count - 1].X ;
            snake.Add(part);
            DrawPart(part);
        }
        public static void ClearPart(Part part)
        {
            Console.SetCursorPosition(part.X, part.Y);
            Console.Write(" ");
        }
        public static void DrawPart(Part part)
        {
            Console.SetCursorPosition(part.X, part.Y);
            Console.Write("*");
        }
        public static void DrawSnake()
        {
            foreach (var item in snake)
	        {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("*");
	        }
        }
        public static void ClearSnake()
        {
            for (int i = 0; i < snake.Count; i++)
            {
                ClearPart(snake[i]);
            }
            snake.Clear();
        }
        public static bool Move()
        {
            switch (direction)
            {
                case Direction.right:
                    if (snake[snake.Count-1].X>=78)
                    {
                        return false;
                    }
                    Right();
                    break;
                case Direction.left:
                    if (snake[snake.Count - 1].X <= 1)
                    {
                        return false;
                    }
                    Left();
                    break;
                case Direction.up:
                    if (snake[snake.Count - 1].Y<= 1)
                    {
                        return false;
                    }
                    Up();
                    break;
                case Direction.down:
                    if (snake[snake.Count - 1].Y >= 22)
                    {
                        return false;
                    }
                    Down();
                    break;
                default:
                    break;
            }
            return true;
        }
        public static void Grow()
        {
            Part part = new Part();
            switch (direction)
            {
                case Direction.right:
                    part.Y = snake[snake.Count - 1].Y;
                    part.X = snake[snake.Count - 1].X+1;
                    break;
                case Direction.left:
                    part.Y = snake[snake.Count - 1].Y;
                    part.X = snake[snake.Count - 1].X-1;
                    break;
                case Direction.up:
                    part.Y = snake[snake.Count - 1].Y-1;
                    part.X = snake[snake.Count - 1].X;
                    break;
                case Direction.down:
                    part.Y = snake[snake.Count - 1].Y+1;
                    part.X = snake[snake.Count - 1].X;
                    break;
                default:
                    break;
            }
            snake.Add(part);
            DrawPart(part);
        }
        public static bool CheckColission(int x,int y)
        {
            for (int i = 0; i < snake.Count; i++)
                {
                    if (snake[i].X==x&&snake[i].Y==y)
                    {
                        return true;
                    }
                }
            return false;
        }

        internal static bool CheckForSelfColission()
        {
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[0].X==snake[i].X && snake[0].Y==snake[i].Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
