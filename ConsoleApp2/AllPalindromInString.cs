using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class AllPalindromInString
    {
        public List<string> all_palindromes(string s)
        {
            List<string> result = new List<string>();
            bool[] visited = new bool[s.Length];

            Generate(result, visited, s, "");

            return result;
        }

        private static void Generate(List<string> result, bool[] visited, string s, string current)
        {
            if (current.Length == s.Length)
            {
                if (IsPalindrom(current))
                {
                    result.Add(current);
                }
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (visited[i])
                    continue;

                visited[i] = true;
                current = current + s[i];
                Generate(result, visited, s, current);
                visited[i] = false;
                current = current.Substring(0, current.Length - 1);
            }
        }

        private static bool IsPalindrom(String word)
        {
            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (word[left] != word[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}
