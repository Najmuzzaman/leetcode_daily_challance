public class Solution {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        int numCols = matrix[0].Length;
        int ans = 0;

        foreach (var currentRow in matrix)
        {
            int[] flippedRow = new int[numCols];
            int count = 0;

            for (int col = 0; col < numCols; col++)
            {
                flippedRow[col] = 1 - currentRow[col];
            }
            foreach (var compareRow in matrix)
            {
                if (Enumerable.SequenceEqual(compareRow, currentRow) ||  Enumerable.SequenceEqual(compareRow, flippedRow))
                    count++;
            }

            ans = Math.Max(ans, count);
        }

        return ans;
    }
}