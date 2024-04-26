public class Solution {
    public int MinFallingPathSum(int[][] grid) {
        int n = grid.Length;
        int res = int.MaxValue;
        int[,] dp = new int[n, n];
        for (int j = 0; j < n; ++j) {
            dp[0, j] = grid[0][j];
        }

        for (int i = 1; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                int ma = int.MaxValue;

                for (int k = 0; k < n; ++k) {
                    if (k != j) {
                        ma = Math.Min(ma, grid[i][j] + dp[i - 1, k]);
                    }
                }

                dp[i, j] = ma;
            }
        }

        for (int j = 0; j < n; ++j) {
            res = Math.Min(res, dp[n - 1, j]);
        }

        return res;
        
    }
}