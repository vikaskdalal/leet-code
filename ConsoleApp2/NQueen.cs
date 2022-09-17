using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class NQueen
    {
        public void Solve(int n)
        {
            List<List<string>> result = new List<List<string>>();

            char[][] matrix = new char[n][];

            for(int i =0; i < n; i++)
            {
                matrix[i] = new char[n];
                for(int j = 0; j < n; j++)
                {
                    matrix[i][j] = '.';
                }
            }

            SolveProblem(matrix,  0, result);

            foreach(var res in result)
            {
                foreach(var item in res)
                    Console.WriteLine(item);
            }
        }

        private List<string> AddResult(char[][] matrix)
        {
            List<string> result = new List<string>();

            for(int i = 0; i < matrix.Length; i++)
            {
                string value = new string(matrix[i]);
                result.Add(value);
            }

            return result;
        }
        private void SolveProblem(char[][] matrix, int row, List<List<string>> result)
        {
            if(row >= matrix.Length)
            {
                result.Add(AddResult(matrix));
                return;
            }

            for(int col=0; col< matrix[0].Length; col++)
            {
                if(IsSafe(matrix, col, row))
                {
                    matrix[row][col] = 'Q';
                    SolveProblem(matrix, row + 1, result);
                    matrix[row][col] = '.';
                }
            }

           
        }

        private bool IsSafe(char[][] matrix, int col, int row)
        {
            for(int i = row, j =col; i>= 0; i--)
            {
                if (matrix[i][j] == 'Q')
                    return false;
            }

            for (int i = row, j = col; i >= 0 && j >=0; i--,j--)
            {
                if (matrix[i][j] == 'Q')
                    return false;
            }

            for (int i = row, j = col; i >= 0 && j < matrix[0].Length; i--, j++)
            {
                if (matrix[i][j] == 'Q')
                    return false;
            }

            return true;
        }
    }
}
