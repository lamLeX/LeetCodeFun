using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Lib
{
    public class TwoSum
    {
        public static int[] FindingTwoSum(int[] nums, int target)
        {
            var lookup = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (lookup.ContainsKey(complement))
                {
                    return new[] { lookup[complement], i };
                }
                lookup.Add(nums[i], i);
            }

            return Enumerable.Empty<int>().ToArray();
        }
    }
}