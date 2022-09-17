using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class PhoneCombination
    {
        public static IList<string> LetterCombinations(string digits)
        {
            IList<string> ans = new List<string>();
            int length = digits.Length;

            if (length == 0)
                return ans;

            string[] numbers = { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            Util(ans, digits, numbers, new StringBuilder(), 0);

            return ans;
        }

        private static void Util(IList<string> ans, string digits, string[] numbers,
                                StringBuilder current, int index)
        {
            if (current.Length > digits.Length)
                return;

            if (current.Length == digits.Length)
            {
                ans.Add(current.ToString());
                return;
            }

            string letters = numbers[digits[index] - '0'];

            for (int i = 0; i < letters.Length; i++)
            {
                current = current.Append(letters[i]);
                Util(ans, digits, numbers, current, index + 1);
                current = current.Remove(current.Length - 1, 1);
            }
        }
    }
}
