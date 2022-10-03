using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class PathFromCornerToMiddleOfMaze
    {
        public static void PrintPath()
        {
        int[,] maze = {
            { 3, 5, 4, 4, 7, 3, 4, 6, 3 },
            { 6, 7, 5, 6, 6, 2, 6, 6, 2 },
            { 3, 3, 4, 3, 2, 5, 4, 7, 2 },
            { 6, 5, 5, 1, 2, 3, 6, 5, 6 },
            { 3, 3, 4, 3, 0, 1, 4, 3, 4 },
            { 3, 5, 4, 3, 2, 2, 3, 3, 5 },
            { 3, 5, 4, 3, 2, 6, 4, 4, 3 },
            { 3, 5, 1, 3, 7, 5, 3, 6, 4 },
            { 6, 2, 4, 3, 4, 5, 4, 5, 1 }
            };

            // Calling the printPath function
            PrintPathUtil(maze, 0, 0, new StringBuilder());
        }

        private static void PrintPathUtil(int[,] maze, int i, int j, StringBuilder sb)
        {
            int row = maze.GetLength(0);
            int col = maze.GetLength(1);
            
            if(i == row /2 && j == col / 2)
            {
                int abc = maze[i, j];
                Console.WriteLine(sb.ToString());
                return;
            }

            if (maze[i, j] == 0)
                return;

            int value = maze[i, j];
            maze[i, j] = 0;

            if(i+value < row)
                PrintPathUtil(maze, i+value, j, sb.Append($"({i},{j}) --> "));

            if (j + value < col)
                PrintPathUtil(maze, i, j + value, sb.Append($"({i},{j}) --> "));

            if (i - value > 0)
                PrintPathUtil(maze, i-value, j, sb.Append($"({i},{j}) --> "));

            if (j - value > 0)
                PrintPathUtil(maze, i, j-value, sb.Append($"({i },{j}) --> "));

            maze[i, j] = value;
        }
    }
}
