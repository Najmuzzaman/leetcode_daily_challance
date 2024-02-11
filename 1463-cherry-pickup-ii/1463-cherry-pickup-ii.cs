public class Solution {
    public int CherryPickup(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        // Create a 3D DP array
        int[][][] dp = new int[rows][][];
        for (int i = 0; i < rows; i++) {
            dp[i] = new int[cols][];
            for (int j = 0; j < cols; j++) {
                dp[i][j] = new int[cols];
                for (int k = 0; k < cols; k++) {
                    dp[i][j][k] = -1;
                }
            }
        }
        
        // Helper function to recursively calculate maximum cherries
        int DFS(int row, int col1, int col2) {
            // Base case: If out of grid or reached the bottom row
            if (row == rows) {
                return 0;
            }
            
            // Check if the value is already computed
            if (dp[row][col1][col2] != -1) {
                return dp[row][col1][col2];
            }
            
            // Calculate the cherries collected by both robots
            int cherries = grid[row][col1];
            if (col1 != col2) {
                cherries += grid[row][col2];
            }
            
            int maxCherries = 0;
            for (int nextCol1 = Math.Max(0, col1 - 1); nextCol1 <= Math.Min(cols - 1, col1 + 1); nextCol1++) {
                for (int nextCol2 = Math.Max(0, col2 - 1); nextCol2 <= Math.Min(cols - 1, col2 + 1); nextCol2++) {
                    maxCherries = Math.Max(maxCherries, DFS(row + 1, nextCol1, nextCol2));
                }
            }
            
            // Update the DP array with the maximum cherries
            dp[row][col1][col2] = cherries + maxCherries;
            return dp[row][col1][col2];
        }
        
        return DFS(0, 0, cols - 1);
    }
}