public class Solution {
    public long GridGame(int[][] grid) {
        int n = grid[0].Length;
        long sumRow1 = 0;
        
        for (int i = 0; i < n; i++)
            sumRow1 += grid[0][i];
            
        long sumRow2 = 0;
        long ans = long.MaxValue;
        for (int i = 0; i < n ; i++) {
            sumRow1 -= grid[0][i];
            ans = Math.Min(ans, Math.Max(sumRow1, sumRow2));
            sumRow2 += grid[1][i];
        }

        return ans;

    }
}