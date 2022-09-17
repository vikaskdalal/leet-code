using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class MaxProduct
    {
        public static int MaxProduct1(int[] nums)
        {
            int abc = ('2'-'0') * ('3'-'0');
            int result = int.MinValue;
            int length = nums.Length;
            int min = 1;
            int max = 1;
            for (int i = 0; i < length; i++)
            {
                if (nums[i] == 0)
                {
                    min = 1;
                    max = 1;
                    continue;
                }
                int temp = nums[i] * max;
                max = Math.Max(nums[i] * max, Math.Max(nums[i] * min, nums[i]));
                min = Math.Min(temp, Math.Max(nums[i] * min, nums[i]));

                result = Math.Max(result, max);
            }

            return result;
        }
    }
}
