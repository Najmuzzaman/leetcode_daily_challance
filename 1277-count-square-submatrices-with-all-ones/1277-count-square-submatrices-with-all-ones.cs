public class Solution {
    public int CountSquares(int[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int[,] dp = new int[m, n];
        int count = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 1)
                {
                    if (i == 0 || j == 0) 
                        dp[i, j] = 1;
                    else
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                    
                    count += dp[i, j];
                }
            }
        }        
        return count;
    }
}