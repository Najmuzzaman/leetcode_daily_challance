public class Solution {
    public int[][] FindFarmland(int[][] land) {
        List<int[]> result = new List<int[]>();
        int m = land.Length;
        int n = land[0].Length;


        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (land[i][j] == 1) {
                    result.Add(findFarmlandCoordinates(land, i, j, m, n));
                }
            }
        }

        return result.ToArray();
    }
    
     private int[] findFarmlandCoordinates(int[][] land, int row, int col, int m, int n) {
        int[] coordinates = new int[4];
        int r = row, c = col;

        while (r < m && land[r][col] == 1) {
            r++;
        }
        while (c < n && land[row][c] == 1) {
            c++;
        }

        coordinates[0] = row;
        coordinates[1] = col;
        coordinates[2] = r - 1;
        coordinates[3] = c - 1;

        for (int i = row; i < r; i++) {
            for (int j = col; j < c; j++) {
                land[i][j] = 0;
            }
        }

        return coordinates;
    }
}