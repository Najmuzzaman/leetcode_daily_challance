public class Solution 
{
     private bool isIsland = true;

    private void dfs(int i, int j, int[][] grid1, int[][] grid2, int n, int m) 
    {
        if (grid1[i][j] == 0)
            isIsland = false;

        grid2[i][j] = 0;

        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };

        for (int k = 0; k < 4; k++) 
        {
            int x = i + dx[k];
            int y = j + dy[k];
            if (x >= 0 && x < n && y >= 0 && y < m && grid2[x][y] == 1)
                dfs(x, y, grid1, grid2, n, m);
        }
    }
    
    public int CountSubIslands(int[][] grid1, int[][] grid2) 
    {
        int count = 0;
        int n = grid2.Length;
        int m = grid2[0].Length;

        for (int i = 0; i < n; i++) 
        {
            for (int j = 0; j < m; j++) 
            {
                if (grid2[i][j] == 1)
                {
                    isIsland = true;
                    dfs(i, j, grid1, grid2, n, m);
                    if (isIsland) count++;
                }
            }
        }
        return count;
    }
}