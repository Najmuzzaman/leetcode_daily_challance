public class Solution {
    public long MaxScore(int[] a, int[] b) {
        int n = b.Length;
        long[] dp = new long[n];
        for (int i = 0; i < n; i++) {
            dp[i] = (long)a[0] *b[i];
        }

        for (int k = 1; k < 4; k++) 
        {
            long[] newDp = new long[n];
            long maxPrev = long.MinValue;
            for (int i = k; i < n; i++) 
            {
                maxPrev = Math.Max(maxPrev, dp[i - 1]);
                newDp[i] = maxPrev + ( (long)a[k] * b[i] );
            }
            dp = newDp;  // Move to the next round
        }

        // Find the maximum score after using all elements from a
        long maxScore = long.MinValue;
        for (int i = 3; i < n; i++) {
            maxScore = Math.Max(maxScore, dp[i]);
        }

        return maxScore;
    }
}