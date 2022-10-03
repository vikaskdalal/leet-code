using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class RemoveInValidBracket
    {
        public static IList<string> RemoveInvalidParentheses(string s)
        {
            IList<string> result = new List<string>();
            HashSet<string> visited = new HashSet<string>();

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(s);
            visited.Add(s);
            bool level = false;
            while (queue.Count != 0)
            {
                s = queue.Dequeue();

                if (IsStringValid(s))
                {
                    result.Add(s);
                    level = true;
                }

                if (level)
                    continue;

                for (int i = 0; i < s.Length; i++)
                {
                    if (!IsParentheses(s[i]))
                        continue;

                    string temp = s.Substring(0, i) + s.Substring(i + 1);

                    if (!visited.Contains(temp))
                    {
                        queue.Enqueue(temp);
                        visited.Add(temp);
                    }

                }
            }

            return result;
        }

        private static bool IsParentheses(char c)
        {
            return c == '(' || c == ')';
        }

        private static bool IsStringValid(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    count++;
                else if (str[i] == ')')
                    count--;

                if (count < 0)
                    return false;
            }

            return count == 0;
        }
    }
}
