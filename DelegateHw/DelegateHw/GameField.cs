using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DelegateHw
{
    public class GameField
    {
        const int FIELD_WIDTH = 20;
        const int FIELD_HEIGHT = 8;

        public bool IsGameOver { get; private set; } = false;
        public int Score { get; set; } = 0;
        public Snake Snake { get; } = new Snake();
        private Food _food;

        public GameField()
        {
            GenerateFood();
        }

        public void GenerateFood(int minHeight = 1, int maxHeight = FIELD_HEIGHT, int minWidth = 1, int maxWidth = FIELD_WIDTH)
        {
            Random rand = new Random();
            int x = rand.Next(minWidth, maxWidth);
            int y = rand.Next(minHeight, maxHeight);

            bool isCrossedWithSnake = false;

            for (int i = 0; i < Snake.Count; i++)
            {
                if (x == Snake[i].X && y == Snake[i].Y)
                {
                    isCrossedWithSnake = true;
                    break;
                }
            }

            if (isCrossedWithSnake)
                GenerateFood();
            else
                _food = new Food(x, y);
        }

        public void CheckCollision()
        {
            if (Snake[0].X == _food.X && Snake[0].Y == _food.Y)
            {
                Snake.FeedSnakeAndMakeLonger();
                GenerateFood();
                Score++;
            }

            if (Snake[0].X > FIELD_WIDTH || Snake[0].Y > FIELD_HEIGHT || Snake[0].Y < 1 || Snake[0].X < 1)
                IsGameOver = true;

            for (int i = 1; i < Snake.Count; i++)
            {
                if (Snake[i].X == Snake[0].X && Snake[i].Y == Snake[0].Y)
                {
                    IsGameOver = true;
                    break;
                }
            }
        }

        public void CheckCollision(object? sender, ElapsedEventArgs e)
        {
            if (Snake[0].X == _food.X && Snake[0].Y == _food.Y)
            {
                Snake.FeedSnakeAndMakeLonger();
                GenerateFood();
                Score++;
            }

            if (Snake[0].X > FIELD_WIDTH || Snake[0].Y > FIELD_HEIGHT || Snake[0].Y < 1 || Snake[0].X < 1)
                IsGameOver = true;

            for (int i = 1; i < Snake.Count; i++)
            {
                if (Snake[i].X == Snake[0].X && Snake[i].Y == Snake[0].Y)
                {
                    IsGameOver = true;
                    break;
                }
            }
        }

        public void PrintGame()
        {
            Console.Clear();
            PrintBorder();
            PrintFood();
            PrintSnake();
            PrintScore();
        }
        
        public void PrintGame(object? sender, ElapsedEventArgs e)
        {
            Console.Clear();
            PrintBorder();
            PrintFood();

            try
            {
                PrintSnake();
            }
            catch 
            {
                Snake.autoMoveTimer.Stop();
            }
            PrintScore();
        }

        public void PrintScore()
        {
            Console.SetCursorPosition(22, 12);
            if (!IsGameOver)
                Console.WriteLine($"SCORE: {Score}");
            else
                Console.WriteLine($"GAME OVER! YOUR SCORE: {Score}");
        }

        public void PrintFood()
        {

            Console.SetCursorPosition(_food.X, _food.Y);
            Console.Write("*");
        }

        public void PrintSnake()
        {
            for (int i = 0; i < Snake.Count; i++)
            {
                Console.SetCursorPosition(Snake[i].X, Snake[i].Y);
                string bodySign = string.Empty;

                if (i == 0)
                    bodySign = "@";
                else
                    bodySign = "%";

                Console.Write(bodySign);
            }
        }

        public void PrintBorder()
        {
            for (int i = 0; i <= FIELD_HEIGHT + 1; i++)
            {
                for (int j = 0; j <= FIELD_WIDTH + 1; j++)
                {
                    if (j == 0 || i == 0 || j == FIELD_WIDTH + 1 || i == FIELD_HEIGHT + 1)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("+");
                    }
                }
            }
        }
    }
}
