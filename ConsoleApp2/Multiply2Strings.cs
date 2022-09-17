using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Multiply2Strings
    {
        public static string Multiply(string num1, string num2)
        {
            int[] res = new int[num1.Length + num2.Length];
            num1 = Reverse(num1);
            num2 = Reverse(num2);
            for (int i = 0; i < num1.Length; i++)
            {
                for (int j = 0; j < num2.Length; j++)
                {
                    int mul = (num1[i] - '0') * (num2[j] - '0');
                    res[i + j] += mul;
                    res[i + j + 1] += res[i + j] / 10;
                    res[i + j] = res[i + j] % 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            int count = res.Length - 1;
            while (count >= 0 && res[count] == 0)
                count--;

            for (int i = 0; i <= count; i++)
                sb.Append(res[i]);

            return sb.ToString();
        }

        private static string Reverse(string num)
        {
            int i = 0;
            int j = num.Length - 1;
            StringBuilder sb = new StringBuilder(num);

            while (i < j)
            {
                char temp = sb[i];
                sb[i] = sb[j];
                sb[j] = temp;

                i++;
                j--;
            }

            return sb.ToString();
        }
    }
}
