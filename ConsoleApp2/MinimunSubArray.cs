using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class MinimunSubArray
    {
        public static int MinSubArrayLen(int target, int[] nums)
        {
            int left = 0;
            int right = 0;
            int ans = int.MaxValue;
            int sum = 0;

            while (right < nums.Length)
            {

                sum += nums[right];

                while (left < right && sum > target)
                {
                    sum -= nums[left];
                    left++;
                }

                if (sum == target)
                    ans = Math.Min(ans, right - left + 1);

                right++;
            }

            return ans;
        }
    }
}
