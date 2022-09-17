using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class SpiralOrder
    {
        public static List<int> spiralOrder(int[,] matrix)
        {
            List<int> ans = new List<int>();

            if (matrix.Length == 0)
                return ans;

            int R = matrix.GetLength(0), C = matrix.GetLength(1);
            bool[,] seen = new bool[R, C];
            int[] dr = { 0, 1, 0, -1 };
            int[] dc = { 1, 0, -1, 0 };
            int r = 0, c = 0, di = 0;

            // Iterate from 0 to R * C - 1
            for (int i = 0; i < R * C; i++)
            {
                ans.Add(matrix[r, c]);
                seen[r, c] = true;
                int cr = r + dr[di];
                int cc = c + dc[di];

                if (0 <= cr && cr < R && 0 <= cc && cc < C
                    && !seen[cr, cc])
                {
                    r = cr;
                    c = cc;
                }
                else
                {
                    di = (di + 1) % 4;
                    r += dr[di];
                    c += dc[di];
                }
            }
            return ans;
        }
    }
}
