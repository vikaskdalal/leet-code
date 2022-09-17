using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class MinimunWindowString
    {
        public string MinWindow(string s, string t)
        {
            int sLength = s.Length;
            int tLength = t.Length;
            string answer = "";

            Dictionary<char, int> hash = new Dictionary<char, int>();

            for (int i = 0; i < tLength; i++)
            {
                hash.Add(t[i], GetValueOrDefault(hash, t[i]) + 1);
            }

            int count = 0;
            int left = 0;
            int right =0;
            Dictionary<char, int> hash1 = new Dictionary<char, int>();

            while (true)
            {
                bool flag1 = false;
                bool flag2 = false;

                // consume
                while (right < sLength  && count < tLength)
                {
                    flag1 = true;

                    hash1[s[right]] = GetValueOrDefault(hash1, s[right]) + 1;

                    if (GetValueOrDefault(hash1, s[right]) <= GetValueOrDefault(hash, s[right]))
                        count++;

                    right++;
                }

                // compare and release
                while (left < right && count == tLength)
                {
                    flag2 = true;
                    
                    string sub = s.Substring(left, right - left );

                    if (answer == "" || sub.Length < answer.Length)
                        answer = sub;



                    if (hash1[s[left]] == 1)
                    {
                        hash1.Remove(s[left]);
                    }
                    else
                    {
                        hash1[s[left]] = hash1[s[left]] - 1;
                    }

                    if (GetValueOrDefault(hash1, s[left]) < GetValueOrDefault(hash, s[left]))
                        count--;
                    left++;
                }



                if (flag1 == false && flag2 == false)
                    break;
            }

            return answer;

        }

        private static int GetValueOrDefault(Dictionary<char, int> hash, char key)
        {
            if (hash.ContainsKey(key))
                return hash[key];

            return 0;
        }
    }
}
