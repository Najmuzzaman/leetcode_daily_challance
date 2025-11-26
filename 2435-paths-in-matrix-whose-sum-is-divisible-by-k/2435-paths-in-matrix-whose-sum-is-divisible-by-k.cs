public class Solution {
    public int NumberOfPaths(int[][] grid, int k) {
        int rows = grid.Length, cols = grid[0].Length;
        int[,,] dp = new int[rows, cols, k];
        dp[0, 0, grid[0][0] % k]++;        
        for (int row = 0; row < rows; row++)        {
            for (int col = 0; col < cols; col++)            {
                int val = grid[row][col] % k;
                for (int mod = 0; mod < k; mod++)                {
                    dp[row, col, (mod + val) % k] += ((row == 0 ? 0 : dp[row - 1, col, mod]) +(col == 0 ? 0 : dp[row, col - 1, mod])) % 1000000007;
                }
            }
        }

        return dp[rows - 1, cols - 1, 0];
    }
}