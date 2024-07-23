public class Solution {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        int n = rowSum.Length;
        int m = colSum.Length;
        int[][] dp = new int[n][];

        for (int i = 0; i < n; i++) 
        {
            dp[i] = new int[m];
            for (int j = 0; j < m; j++) 
            {
                int a = Math.Min(rowSum[i], colSum[j]);
                dp[i][j] = a;
                rowSum[i] -= a;
                colSum[j] -= a;
            }
        }
        
        return dp;
    }
}