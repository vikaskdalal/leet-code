using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {

        private static void Helper(int[] nums, IList<IList<int>> ans, IList<int> temp, bool[] visited)
        {
            if (temp.Count == nums.Length)
            {
                ans.Add(new List<int>(temp));

                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (visited[i])
                    continue;

                temp.Add(nums[i]);
                visited[i] = true;

                Helper(nums, ans, temp, visited);
                temp.RemoveAt(temp.Count - 1);
                visited[i] = false;
            }
        }


        private static void abc()
        {
            string s = "abcabcbb";
            int length = s.Length;
            int max = 0;

            

            int left = 0;
            int right = 0;
            Dictionary<char, int> hash = new Dictionary<char, int>();

            while (right < length)
            {
                max = Math.Max(max, right - left + 1);
                if (!hash.ContainsKey(s[right]))
                {
                    
                    hash.Add(s[right], right);
                    
                    right++;
                }
                else
                {
                    if (hash[s[right]] >= left)
                    {

                        left = hash[s[right]] + 1;
                    }
                    hash[s[right]] = right;
                    right++;

                }


            }

        }


        private static void RoteOrange()
        {
           
            int[][] grid =
            {
                new int[]{2,1,1 },
                new int[]{1,1,0 },
                new int[]{0,1,1 },
                //[0,1,1],
                //[1,0,1]
            };
            int row = grid.Length;
            int col = grid[0].Length;
            int freshOrange = 0;

            int[][] directions = {
            new int[]{1,0},
            new int[]{-1,0},
            new int[]{0,1},
            new int[]{0,-1}
        };
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue(new int[] { i, j, 0 });
                    }
                    else if (grid[i][j] == 1)
                        freshOrange++;
                }
            }

            
                

            while (queue.Count != 0)
            {

                int[] takeOut = queue.Dequeue();
                int x = takeOut[0];
                int y = takeOut[1];

                for (int j = 0; j < directions.Length; j++)
                {
                    int nx = x + directions[j][0];
                    int ny = y + directions[j][1];

                    if (nx >= 0 && ny >= 0 && nx < row && ny < col &&
                      grid[nx][ny] == 1)
                    {
                        grid[nx][ny] = 2;

                        freshOrange--;
                        Console.WriteLine("hello");


                        queue.Enqueue(new int[] { nx, ny, takeOut[2] + 1 });
                    }
                }
                Console.WriteLine(queue.Count);

            }


            Console.WriteLine("end");
        }


        public static int StrStr(string haystack, string needle)
        {
            int nLength = needle.Length;
            int hLength = haystack.Length;

            if (nLength > hLength)
                return -1;

            int n = 0;
            int h = 0;


            while (h < hLength)
            {
                if (needle[n] == haystack[h])
                {
                    if (n == nLength)
                        return h - n + 1;
                    n++;
                    h++;
                }
                else
                {
                    if (n > 0)
                    {
                        h = h - n;
                        n = 0;
                    }
                    else
                    {
                        h++;
                    }
                }
            }

            return -1;
        }

        public static int Compress(char[] chars)
        {
            if (chars.Length == 1)
                return 1;

            int index = 0;
            int count = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                count++;

                if (i + 1 >= chars.Length || chars[i] != chars[i + 1])
                {
                    index++;
                    if (count != 0)
                    {
                        chars[index] = (char)count;
                        count = 0;
                    }
                    index++;
                }


            }

            return index;
        }

        public static int SingleNumber(int[] nums)
        {
            int ans = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                ans = ans ^ nums[i];
            }


            return ans;
        }

        public static string DecodeString(string s)
        {
            int length = s.Length;
            Stack<string> stack = new Stack<string>();
            Stack<int> stack1 = new Stack<int>();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    int num = 0;
                    while (s[i] >= '0' && s[i] <= '9')
                    {
                        num = num * 10 + (s[i] - '0');
                        i++;
                    }
                    i--;
                    stack1.Push(num);
                }
                else if (s[i] == ']')
                {
                    StringBuilder word = new StringBuilder();

                    while (stack.Count != 0 && stack.Peek() != "[")
                    {
                        word.Insert(0, stack.Pop());
                    }

                    if (stack.Count >= 1)
                    {
                        stack.Pop();

                        int num = stack1.Pop();
                        string chars = word.ToString();
                        for (int j = 0; j < num; j++)
                        {

                            stack.Push(chars);
                        }
                    }
                }
                else
                {
                    stack.Push(s[i].ToString());
                }

            }

            while (stack.Count != 0)
                sb.Insert(0, stack.Pop());

            return sb.ToString();
        }

        public static int Rob(int[] nums)
        {
            int length = nums.Length;

            if (length == 0)
                return 0;
            else if (length == 1)
                return 1;
            else
            {
                int abca = Util(nums, 0, length - 1);
                int asf = Util(nums, 1, length-1 );
                return Math.Max(Util(nums, 0, length - 1), Util(nums, 1, length ));
            }
                
        }

        private static int Util(int[] nums, int start, int end)
        {
            int[] dp = new int[nums.Length-1];

            dp[0] = nums[start];
            dp[1] = Math.Max(nums[start], nums[start + 1]);

            for (int i =2; i < end; i++)
            {
                dp[i] = Math.Max(dp[i - 1], nums[i+start] + dp[i - 2]);
            }

            return dp[dp.Length - 1];
        }

        public static int TotalFruit(int[] fruits)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();

            int left = 0;
            int right = 0;
            int max = 0;
            while (right < fruits.Length)
            {
                if (hash.ContainsKey(fruits[right]))
                {
                    hash[fruits[right]] += 1;
                }
                else
                {
                    hash.Add(fruits[right], 1);
                }

                while (left <= right && hash.Count > 2)
                {
                    if (hash[fruits[left]] > 1)
                        hash[fruits[left]] -= 1;
                    else
                        hash.Remove(fruits[left]);

                    left++;
                }

                max = Math.Max(max, right - left + 1);
                right++;
            }

            return max;
        }

        static void Main(string[] args)
        {
            int a11 = -1 % 20;
            List<int> set = new List<int>();
            HashSet<int> set1 = new HashSet<int>();
            set1.Add(1);
            
            set.Add(3);
            set.Add(4);
            set.Add(10);
            set.Add(3);
            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            //set.AddAllElements(new List<int>());
            set.Sort((a1, b) => b.CompareTo(a1));

            MinimunSubArray.MinSubArrayLen(11, new int[] { 1,2,3,4,5 });
            Multiply2Strings.Multiply("123", "456");
            MaxProduct.MaxProduct1(new int[] { -2, 0, -1 });
            int[,] a = { { 1, 2, 3, 4 },
                      { 5, 6, 7, 8 },
                      { 9, 10, 11, 12 },
                      { 13, 14, 15, 16 } };

            SpiralOrder.spiralOrder(a).ForEach(i => Console.Write(i + " "));
            PhoneCombination.LetterCombinations("23");
            TotalFruit(new int[] {3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 });
            CelebrityProblem.findPotentialCelebrity(4);
            Rob(new int[] { 1, 2, 3, 10 });
            new CombinationSum4().CombinationSum(new int[] { 1, 2, 3 }, 4);
            DecodeString("100[leetcode]");
            SingleNumber(new int[] { 4, 1, 2, 1, 2 });
            var vik = '9' - 'a';
            int[,] dp = new int[5, 6];

            int assd = dp.Length;

            new SuperSetOfString().FindSuperset("abc");
            new LetterCasePermutation().LetterCasePermutation1("a1b2");
            Compress(new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' });
           new AllPalindromInString().all_palindromes("abbab");
            new MinimunWindowString().MinWindow("ADOBECODEBANC", "ABC");
            new NQueen().Solve(4);

            StrStr("sadbutsad", "sad");
            StringBuilder sb = new StringBuilder();

            string vikas = "vikkis";
            char[] vikass = new char[26];

            foreach (var v in vikas)
                vikass[v - 'a']++;
            //RoteOrange();
            //int ass = 1 / 3;

            string nh = new String(vikass);
            //abc();

            int[]  nums1= { 1, 2, 3 };
            IList<IList<int>> ans1 = new List<IList<int>>();
            IList<int> temp1 = new List<int>();
            bool[] visited = new bool[nums1.Length];

            Helper(nums1, ans1, temp1, visited);
            //string[] a = { "one", "two", "three", "four", "five" };
            //var segment = new ArraySegment<string>(a);
            //segment.RemoveAt()

            var numbers1 = new[] { 1, 2, 3, 4 };
            var segment = new ArraySegment<int>(numbers1,0,1);
            var segmen1t = new ArraySegment<int>(numbers1, 2, 2);



            string digits = "23";
            var ty = int.Parse(digits[0] .ToString());
            IList<string> ans = new List<string>();
            int length = digits.Length;

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("");
            string[] numbers = { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            while (queue.Count != 0)
            {
                string word = queue.Dequeue();

                if (word.Length == length)
                {
                    ans.Add(word);
                }
                else
                {
                    string s = numbers[digits[word.Length]];

                    for (int i = 0; i < s.Length; i++)
                    {
                        string neww = $"{word}{s[i]}";
                        queue.Enqueue(neww);
                    }
                }
            }



            int[,] visited1 = new int[5,4];
            int[] nums = { 1, 3, 4, 2, 2 };
            foreach (var value in nums)
            {
                int indexValue = Math.Abs(value);

                if (nums[indexValue] < 0)
                    Console.WriteLine(indexValue);

                nums[indexValue] = -nums[indexValue];
            }


            int[] candidates = {2,3,6,7};
            int target = 7;
            IList<IList<int>> answer = new List<IList<int>>();
            IList<int> temp = new List<int>();

            FindCombinations(candidates, answer, temp, 0, 0, target);

            Console.WriteLine(answer);

        }

        private static void FindCombinations(int[] candidates, IList<IList<int>> answer,
                                 IList<int> temp, int sum, int index, int target)
        {
            int length = candidates.Length;
            if (index >= length || sum > target)
                return;
            else if (sum == target)
            {
                answer.Add(new List<int>(temp));
                return;
            }

            for (int i = index; i < length; i++)
            {
                temp.Add(candidates[i]);
                FindCombinations(candidates, answer, temp, sum + candidates[i], i, target);
                temp.Remove(candidates[i]);
            }
        }
    }
}
