public class Solution {
    public int CountSquares(int[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;        
        int[,] dp = new int[m, n];
        int cntSq = 0;
        
        for (int i = 0; i < m; i++) 
        {
            for (int j = 0; j < n; j++) 
            {
                if (matrix[i][j] == 1) 
                {
                    if (i == 0 || j == 0) 
                        dp[i, j] = 1; 
                    else 
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j],Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                    
                    cntSq += dp[i, j];
                }
            }
        }
        
        return cntSq;
    }
}