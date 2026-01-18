public class Solution {
    private int m, n, sqSize;
    private int[][] rowSum, colSum, diaglr, diagrl;
    private void PreCal(int[][] grid)
    {
        for(int i = 0; i < m; i++)
        {
            rowSum[i] = new int[n];
            colSum[i] = new int[n];
            diaglr[i] = new int[n];
            diagrl[i] = new int[n];
        }

        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                int curV = grid[i][j];
                rowSum[i][j] = curV + (i > 0 ? rowSum[i-1][j] : 0);
                colSum[i][j] = curV + (j > 0 ? colSum[i][j-1] : 0);
                diaglr[i][j] = curV + (i > 0 && j > 0 ? diaglr[i-1][j-1] : 0);
                diagrl[i][j] = curV + (i > 0 && j < n-1 ? diagrl[i-1][j+1] : 0);
            }
        }
    }

    private bool AllEqual(int i, int j, int size)
    {
        int top = i, bottom = i+size-1, left = j, right = j+size-1;
        int sum = rowSum[bottom][left] - (top == 0 ? 0 : rowSum[top-1][left]);

        // Check rowSum:
        for(int p = left; p <= right; p++)
        {
            int diff = rowSum[bottom][p] - (top == 0 ? 0 : rowSum[top-1][p]);
            if(diff != sum)
                return false;
        }

        // Check ColSum:
        for(int p = top; p <= bottom; p++)
        {
            int diff = colSum[p][right] - (left == 0 ? 0 : colSum[p][left-1]);
            if(diff != sum)
                return false;
        }

        // Check diag:
        int diagDiff1 = diaglr[bottom][right] - (top > 0 && left > 0 ? diaglr[top-1][left-1] : 0);
        int diagDiff2 = diagrl[bottom][left] - (top > 0 && right < n-1 ? diagrl[top-1][right+1] : 0);

        return diagDiff1 == sum && diagDiff2 == sum;
    }

    public int LargestMagicSquare(int[][] grid) {
        m = grid.Length;
        n = grid[0].Length;
        sqSize = Math.Min(m, n);
        if(sqSize < 2)
            return sqSize;

        rowSum = new int[m][];
        colSum = new int[m][];
        diaglr = new int[m][];
        diagrl = new int[m][];

        PreCal(grid);
        while(sqSize >1)
        {
            for(int i = 0; i <= m-sqSize; i++)
            {
                for(int j = 0; j <= n-sqSize; j++)
                {
                    if(AllEqual(i, j, sqSize))
                        return sqSize;
                }
            }

            sqSize--;
        }

        return 1;
    }
}