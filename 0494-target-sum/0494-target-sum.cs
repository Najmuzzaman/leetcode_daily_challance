public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        int total = nums.Sum();
        int n = nums.Length;
        int[,] dp = new int[n, 2 * total + 1];

        dp[0,nums[0] + total] = 1;
        dp[0,-nums[0] + total] += 1;

        for (int i = 1; i < n; i++)
        {
            for (int j = -total; j <= total; j++)
            {
                if (dp[i - 1,j + total] > 0)
                {
                    dp[i, j + nums[i] + total] += dp[i - 1, j + total];
                    dp[i, j - nums[i] + total] +=dp[i - 1, j + total];
                }
            }
        }
        return Math.Abs(target) > total? 0 :dp[n - 1, target + total];
    }
}