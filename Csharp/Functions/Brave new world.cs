using System;
using System.IO;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = ReadMap("MAP.txt");

            int cordinateY = 2;
            int cordinateX = 1;

            char wall = '*';
            char space = ' ';

            int tempY = cordinateY;
            int tempX = cordinateX;

            bool isActive = true;

            while (isActive)
            {
                DrawCharacter(ref map, cordinateX, cordinateY);

                DrawMap(map);

                GetInput(ref tempY, ref tempX);

                if (map[tempX, tempY] != wall)
                {
                    map[cordinateX, cordinateY] = space;

                    MoveCharacter(ref cordinateX, ref cordinateY, tempX, tempY);

                    DrawCharacter(ref map, cordinateX, cordinateY);
                }
                else
                {
                    tempX = cordinateX;
                    tempY = cordinateY;
                }

                Console.Clear();
            }
        }

        static void MoveCharacter(ref int x, ref int y, int newPositionX, int newPositionY)
        {
            x = newPositionX;
            y = newPositionY;
        }

        static char[,] DrawCharacter(ref char[,] map, int x, int y)
        {
            char character = '@';
            map[x, y] = character;
            return map;
        }

        static void GetInput(ref int x, ref int y)
        {
            ConsoleKey pressedKey = Console.ReadKey().Key;

            if (pressedKey == ConsoleKey.UpArrow)
            {
                x--;
            }
            else if (pressedKey == ConsoleKey.DownArrow)
            {
                x++;
            }
            else if (pressedKey == ConsoleKey.LeftArrow)
            {
                y--;
            }
            else if (pressedKey == ConsoleKey.RightArrow)
            {
                y++;
            }
        }

        static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines("MAP.txt");

            char[,] map = new char[GetMaxLenght(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }

            return map;
        }

        static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }

                Console.WriteLine();
            }
        }

        static int GetMaxLenght(string[] lines)
        {
            int maxLenght = lines[0].Length;

            foreach (string line in lines)
            {
                if (line.Length > maxLenght)
                {
                    maxLenght = line.Length;
                }
            }

            return maxLenght;
        }
    }
}
