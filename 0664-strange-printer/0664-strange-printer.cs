public class Solution {
    public int StrangePrinter(string s) {
         int n = s.Length;
        if (n == 0) 
            return 0;
        

        int[,] dp = new int[n, n];
        
        for (int i = 0; i < n; i++)
            dp[i, i] = 1;

        for (int j = 2; j <= n; j++) 
        {
            for (int i = 0; i <= n - j; i++)
            {
                int k = i + j - 1;
                dp[i, k] = dp[i + 1, k] + 1;
                for (int l = i + 1; l <= k; l++) 
                {
                    if (s[l] == s[i])
                        dp[i, k] = Math.Min(dp[i, k], dp[i + 1, l - 1] + dp[l, k]);
                }
            }
        } 

        return dp[0, n - 1];
    }
}