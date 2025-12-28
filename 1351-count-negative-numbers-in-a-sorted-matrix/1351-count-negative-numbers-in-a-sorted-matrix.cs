public class Solution {
    public int CountNegatives(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length - 1;

        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (grid[i][m] < 0)
            {
                count += n - i;
                m--;
                i--;
                if (m < 0) break;
            }
        }

        return count;
    }
}