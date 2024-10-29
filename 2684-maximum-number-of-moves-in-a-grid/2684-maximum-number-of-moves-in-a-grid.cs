public class Solution {
    int n, m;
    int[] X = new int[3] { -1, 0, 1};
    int[] Y = new int[3] {  1, 1, 1};
    int[][] visit;
    public int MaxMoves(int[][] grid) {
        n = grid.Length;
        m = grid[0].Length;
        visit = new int[n][];
        for (int i = 0; i < n; i++) 
        {
            visit[i] = new int[m];
            Array.Fill(visit[i], -1);
        }
        int ans = 0;
        for(int i=0;i<n;i++)
        {
            int re=dfs(grid, i, 0, 0);
            ans = Math.Max(ans, re);
        }
        return ans;
    }
    int dfs(int[][]grid, int x,int y, int d)
    {
         if (visit[x][y] != -1) return visit[x][y];
        int maxd = d;
        for(int i=0;i<3;i++)
        {
            int u = x + X[i];
            int v = y + Y[i];            
            if (u >= 0 && v >= 0 && u < n && v < m && grid[u][v] > grid[x][y])
            {
                maxd=Math.Max(maxd,dfs(grid, u, v, d + 1));
            }
        }
        visit[x][y]=maxd;
        return maxd;
    }
}