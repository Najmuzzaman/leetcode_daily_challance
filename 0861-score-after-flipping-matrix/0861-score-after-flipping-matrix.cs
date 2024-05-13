public class Solution {
    public int MatrixScore(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        int ans = (1 << (m - 1)) * n;
        for(int j = 1; j < m; j++)
        {
            int v = 1 << (m - 1 - j);
            int s = 0;
            for(int i = 0; i < n; i++)
                if(grid[i][j] == grid[i][0])
                    s++;
            ans += Math.Max(s, n - s) * v;
        }
        return ans;
    }
}