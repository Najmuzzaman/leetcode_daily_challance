public class Solution {
    int[] roww = {1, -1, 0, 0};
    int[] coll = {0, 0, -1, 1};
    
    public int dfs(int[][] grid, int x, int y, int n, int m) {
        if (x < 0 || x >= n || y < 0 || y >= m || grid[x][y] == 0) return 0;
        
        int curr = grid[x][y];
        grid[x][y] = 0;
        int maxGold = curr;

        for (int i = 0; i < 4; i++) 
        {
            int newX = x + roww[i];
            int newY = y + coll[i];
            maxGold = Math.Max(maxGold, curr + dfs(grid, newX, newY, n, m));
        }
        grid[x][y] = curr;
        return maxGold;
    }
    public int GetMaximumGold(int[][] grid) 
    {
        int n = grid.Length, m = grid[0].Length;
        int maxGold = 0;
        for (int i = 0; i < n; i++) 
        {
            for (int j = 0; j < m; j++) 
            {
                if (grid[i][j] != 0)
                    maxGold = Math.Max(maxGold, dfs(grid, i, j, n, m));
            }
        }

        return maxGold;
    }
}