public class Solution {
    public int IslandPerimeter(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        int cnt = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) {
                    cnt += 4; // Every island cell contributes 4 sides
                    // Check adjacent cells and reduce perimeter for shared sides
                    if (i > 0 && grid[i - 1][j] == 1) cnt -= 2; // Top neighbor
                    if (j > 0 && grid[i][j - 1] == 1) cnt -= 2; // Left neighbor
                }
            }
        }
        return cnt;
    }
}