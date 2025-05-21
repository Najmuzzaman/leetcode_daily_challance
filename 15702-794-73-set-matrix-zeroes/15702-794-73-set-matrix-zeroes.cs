public class Solution {
    public void SetZeroes(int[][] matrix) {
        int n= matrix.Length;
        int m=matrix[0].Length;
        bool resetRow = matrix[0].Contains(0);
        bool resetCol = false;
        for (int i = 0; i < n; i++)
            if (matrix[i][0] == 0)
                resetCol = true;
        
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (matrix[i][j] == 0)
                {
                    matrix[0][j] = 0;
                    matrix[i][0] = 0;
                }
        

        for (int i = 1; i < n; i++)
            for (int j = 1; j < m; j++)
                if (matrix[i][0] == 0 || matrix[0][j] ==0)
                    matrix[i][j] = 0;

        if (resetRow)
            for (int i = 0; i < m; i++)
                matrix[0][i] = 0;

        if (resetCol)
            for (int i = 0; i < n; i++)
                matrix[i][0] = 0;
    }
}