public class Solution {
    public int NumSubmat(int[][] mat) {
        int n = mat.Length;
        int m = mat[0].Length;

        for (int i = 1; i < n; i++)
            for (int j = 0; j < m; j++)
                if (mat[i][j] != 0)
                    mat[i][j] += mat[i - 1][j];

        int result = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (mat[i][j] == 0) continue;
                int min = mat[i][j];
                for (int k = j; k < m; k++)
                {
                    min = Math.Min(min, mat[i][k]);
                    if (min == 0) break;
                    result += min;
                }
            }
        }
        return result;
    }
}