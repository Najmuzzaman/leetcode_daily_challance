public class Solution {
    public int MinimumArea(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        int minRow = int.MaxValue;
        int maxRow = int.MinValue;
        int minCol = int.MaxValue;
        int maxCol = int.MinValue;

        for( int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                if (grid[row][col] == 1)
                {
                    minCol = Math.Min(minCol, col);
                    minRow = Math.Min(minRow, row);
                    maxCol = Math.Max(maxCol, col);
                    maxRow = Math.Max(maxRow, row);
                }
            }
        }

        return (maxRow - minRow + 1) * (maxCol - minCol + 1);
    }
}