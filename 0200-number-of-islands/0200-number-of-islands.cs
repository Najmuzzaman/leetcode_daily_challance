public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0)
            return 0;
        
        int n = grid.Length;
        int m = grid[0].Length;
        int numIslands = 0;
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == '1') {
                    numIslands++;
                    DFS(grid, i, j);
                }
            }
        }
        return numIslands;
    }
    private void DFS(char[][] grid, int row, int col) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        if (row < 0 || col < 0 || row >= rows || col >= cols || grid[row][col] == '0')
            return;
        
        grid[row][col] = '0';
        DFS(grid, row + 1, col);
        DFS(grid, row - 1, col);
        DFS(grid, row, col + 1);
        DFS(grid, row, col - 1);
    }
}