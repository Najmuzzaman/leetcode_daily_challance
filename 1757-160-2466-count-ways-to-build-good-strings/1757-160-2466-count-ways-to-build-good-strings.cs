public class Solution {
    public int CountGoodStrings(int low, int high, int zero, int one) {
        long Mod=1000000007;
        long ans=0;
        long[] dp=new long[high+1];
        dp[0] = 1;

        for (int i=1; i<=high;i++)
        {
            if (i >= zero)
                dp[i] = (dp[i] + dp[i - zero]) % Mod;
            if (i >= one)
                dp[i] = (dp[i] + dp[i - one]) % Mod;
            if (i >= low)
                ans = (ans + dp[i]) % Mod;
        }
        return (int)ans;
    }
}