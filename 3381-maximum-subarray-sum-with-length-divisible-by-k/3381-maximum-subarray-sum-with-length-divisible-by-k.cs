public class Solution {
    public long MaxSubarraySum(int[] nums, int k) {        
        int n = nums.Length;
        long[] preSum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            preSum[i + 1] = preSum[i] + nums[i];
        }

        Dictionary<int, long> mp = new Dictionary<int, long>();
        long maxSum = long.MinValue;

        for (int i = 0; i <= n; i++)
        {
            int mod = i % k;
            if (mp.ContainsKey(mod))
            {
                maxSum = Math.Max(maxSum, preSum[i] - mp[mod]);
                mp[mod] = Math.Min(mp[mod], preSum[i]);
            }
            else
                mp[mod] = preSum[i];                
        }

        return maxSum == long.MinValue ? 0 : maxSum;
    }
}