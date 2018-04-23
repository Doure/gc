using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public class Game
        {
            private struct Point
            {
                public int X { get; set; }
                public int Y { get; set; }

                public Point(int x, int y)
                {
                    X = x;
                    Y = y;
                }
            }

            private int[,] map = new int[5, 5];
            private Point myPoint = new Point();

            public Game()
            {
                Random rand = new Random();
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        map[i, j] = rand.Next(1, 9);
                    }
                }
            }
            private void swap(Point point1, Point point2)
            {
                int tmp = map[point1.Y, point1.X];

                map[point1.Y, point1.X] = map[point2.Y, point2.X];

                map[point2.Y, point2.X] = tmp;
            }
            public void Run()
            {
                while (true)
                {
                    Draw();

                    Console.SetCursorPosition(myPoint.X, myPoint.Y);

                    var input = Console.ReadKey().Key;

                    switch (input)
                    {
                        case ConsoleKey.W:
                            if (myPoint.Y > 0)
                            {
                                if (map[myPoint.Y - 1, myPoint.X] > map[myPoint.Y, myPoint.X])
                                    ++map[myPoint.Y, myPoint.X];
                                else if (map[myPoint.Y - 1, myPoint.X] < map[myPoint.Y, myPoint.X])
                                    --map[myPoint.Y, myPoint.X];

                                swap(new Point(myPoint.X, myPoint.Y), new Point(myPoint.X, myPoint.Y - 1));

                                myPoint.Y--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (myPoint.Y < map.GetLength(0) - 1)
                            {
                                if (map[myPoint.Y + 1, myPoint.X] > map[myPoint.Y, myPoint.X])
                                    ++map[myPoint.Y, myPoint.X];
                                else if (map[myPoint.Y + 1, myPoint.X] < map[myPoint.Y, myPoint.X])
                                    --map[myPoint.Y, myPoint.X];

                                swap(new Point(myPoint.X, myPoint.Y), new Point(myPoint.X, myPoint.Y + 1));

                                myPoint.Y++;
                            }
                            break;
                        case ConsoleKey.A:
                            if (myPoint.X > 0)
                            {
                                if (map[myPoint.Y, myPoint.X - 1] > map[myPoint.Y, myPoint.X])
                                    ++map[myPoint.Y, myPoint.X];
                                else if (map[myPoint.Y, myPoint.X - 1] < map[myPoint.Y, myPoint.X])
                                    --map[myPoint.Y, myPoint.X];

                                swap(new Point(myPoint.X, myPoint.Y), new Point(myPoint.X - 1, myPoint.Y));

                                --myPoint.X;
                            }
                            break;
                        case ConsoleKey.D:
                            if (myPoint.X < map.GetLength(1) - 1)
                            {
                                if (map[myPoint.Y, myPoint.X + 1] > map[myPoint.Y, myPoint.X])
                                    ++map[myPoint.Y, myPoint.X];
                                else if (map[myPoint.Y, myPoint.X + 1] < map[myPoint.Y, myPoint.X])
                                    --map[myPoint.Y, myPoint.X];

                                swap(new Point(myPoint.X, myPoint.Y), new Point(myPoint.X + 1, myPoint.Y));

                                ++myPoint.X;
                            }
                            break;
                    }
                    Console.Clear();
                }
            }
            private void Draw()
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write("{0}", map[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Game game = new Game();

            game.Run();
        }
    }
}
