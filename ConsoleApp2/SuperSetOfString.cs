using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class SuperSetOfString
    {
        public void FindSuperset(string word)
        {
            List<string> result =  new List<string>();
            StringBuilder sb = new StringBuilder();

            Find(word, result, sb, 0);
        }

        private void Find(string word, List<string> result, StringBuilder sb, int index)
        {
            result.Add(sb.ToString());

            if (index >= word.Length)
                return;

            for(int i = index; i < word.Length; i++)
            {
                sb = sb.Append(word[i]);
                Find(word, result, sb, i+1);

                sb = sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
