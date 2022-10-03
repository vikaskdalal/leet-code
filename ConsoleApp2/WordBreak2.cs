using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class WordBreak2
    {
        public static IList<string> WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> map = new HashSet<string>(wordDict);
            IList<string> result = new List<string>();

            WordBreakUtil(s, map, result, new StringBuilder());

            return result;
        }

        private static void WordBreakUtil(string s, HashSet<string> map, IList<string> result,
            StringBuilder sb)
        {
            if (s.Length == 0)
            {
                result.Add(sb.ToString().TrimEnd());
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                string prefix = s.Substring(0, i + 1);
                string suffix = s.Substring(i + 1);

                if (map.Contains(prefix))
                {
                    sb = sb.Append(prefix + " ");
                    WordBreakUtil(suffix, map, result, sb);

                    sb = sb.Remove(sb.Length - prefix.Length-1, prefix.Length+1);

                }
            }
        }
    }
}
