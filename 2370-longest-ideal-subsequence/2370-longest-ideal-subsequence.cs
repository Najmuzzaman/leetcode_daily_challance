public class Solution {
    public int LongestIdealString(string s, int k) {
        int[] dp = new int[150];
        int res = 0;
        foreach (char c in s)
        {
            for (int d = c - k; d <= c + k; ++d)
            {
                if (d >= 0 && d < dp.Length) // Ensure d is within array bounds
                {
                    dp[c] = Math.Max(dp[c], dp[d]);
                }
            }
            res = Math.Max(res, ++dp[c]);
        }
        return res;
    }
}