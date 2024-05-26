public class Solution
{
    public int CheckRecord(int n) 
    {
        int MOD = 1000000007;
        int[,,] dp = new int[n + 1, 2, 3];        
        dp[0, 0, 0] = 1;
        for (int i = 1; i <= n; i++) 
        {
            for (int j = 0; j < 2; j++) 
            {
                for (int k = 0; k < 3; k++) 
                {
                    // Append 'P'
                    dp[i, j, 0] = (dp[i, j, 0] + dp[i - 1, j, k]) % MOD;
                    // Append 'A'
                    if (j < 1)
                        dp[i, j + 1, 0] = (dp[i, j + 1, 0] + dp[i - 1, j, k]) % MOD;
                    // Append 'L'
                    if (k < 2) 
                        dp[i, j, k + 1] = (dp[i, j, k + 1] + dp[i - 1, j, k]) % MOD;
                }
            }
        }
        // Sum all valid sequences of length n
        int result = 0;
        for (int j = 0; j < 2; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                result = (result + dp[n, j, k]) % MOD;
            }
        }
        return result;
    }
}