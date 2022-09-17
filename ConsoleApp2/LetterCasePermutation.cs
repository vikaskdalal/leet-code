using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class LetterCasePermutation
    {
        public IList<string> LetterCasePermutation1(string s)
        {
            int abc = 6 >> 3;
            IList<string> res = new List<string>();

            StringBuilder sb = new StringBuilder();

            Generate(res, sb, s.ToLower(), 0);

            return res;
        }

        private static void Generate(IList<string> res, StringBuilder sb,
                                     string s, int index)
        {
            if (index >= s.Length)
            {
                res.Add(sb.ToString());
                return;
            }

            Generate(res, sb.Append(s[index]), s, index + 1);

            sb = sb.Remove(sb.Length - 1, 1);

            if (s[index] >= 'a' && s[index] <= 'z')
            {
                Generate(res, sb.Append(s[index].ToString().ToUpper()), s, index + 1);
                sb = sb.Remove(sb.Length - 1, 1);
            }
                

        }
    }
}
