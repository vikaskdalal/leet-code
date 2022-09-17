using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CombinationSum4
    {
        public int CombinationSum(int[] nums, int target)
        {
            int ans = Util(nums, target);

            return ans;
        }

        private static int Util(int[] nums, int target)
        {
            if (target == 0)
            {
                return 1;
            }

            int ans = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (target - nums[i] < 0)
                    continue;

                ans += Util(nums, target - nums[i]);

            }

            return ans;
        }
    }
}
