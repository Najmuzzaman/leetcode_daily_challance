public class Solution {
   
    private int CountIslands(int[][] grid) 
    {
        int m = grid.Length;
        int n = grid[0].Length;
        bool[,] visited = new bool[m, n];

        int islands = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1 && !visited[i, j]) {
                    islands++;
                    Dfs(m, n, grid, visited, i, j);
                }
            }
        }
        return islands;
    }
        
    void Dfs(int m,int n,int[][] grid, bool[,] visited, int i, int j) 
    {
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == 0 || visited[i, j])
            return;

        visited[i, j] = true;

        int[][] directions = new int[][] {
            new int[] {0, 1}, new int[] {1, 0}, 
            new int[] {0, -1}, new int[] {-1, 0}
        };

        foreach (var dir in directions) 
        {
            int x = i + dir[0];
            int y = j + dir[1];
            Dfs(m, n, grid, visited, x, y);
        }
    }
    private int[][] CloneGrid(int[][] grid) 
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] clone = new int[m][];
        for (int i = 0; i < m; i++)
        {
            clone[i] = new int[n];
            for (int j = 0; j < n; j++)
                clone[i][j] = grid[i][j];
        }
        return clone;
    }
    
    public int MinDays(int[][] grid) 
    {
        int originalIslands = CountIslands(CloneGrid(grid));
        if (originalIslands != 1)
            return 0;

        for (int i = 0; i < grid.Length; i++) 
        {
            for (int j = 0; j < grid[0].Length; j++) 
            {
                if (grid[i][j] == 1) {
                    grid[i][j] = 0;
                    if (CountIslands(CloneGrid(grid)) != 1)
                        return 1;
                    
                    grid[i][j] = 1;
                }
            }
        }

        return 2;
    }
}