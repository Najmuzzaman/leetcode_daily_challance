public class Solution {
    public int NumberOfWays(int n, int x) {
        int MOD = 1000000007;
        int nn = (int) Math.Pow(n, 1.0 / x) + 1;
        int[][] dp = new int[nn + 1][];
        for (int i = 0; i <= nn; i++) 
        {
            dp[i] = new int[n + 1];
            dp[i][0] = 1;
        }

        for (int i = 1; i <= nn; i++) 
        {
            for (int j = 1; j <= n; j++)
                if (j < Math.Pow(i, x)) 
                    dp[i][j] = dp[i - 1][j];
                else 
                    dp[i][j] = (dp[i - 1][j] + dp[i - 1][j - (int)Math.Pow(i, x)]) % MOD;            
        }
        return dp[nn][n];
    }
}