public class Solution {
    public long MaxMatrixSum(int[][] matrix) {
        long Total = 0;
        int minAbsVal = int.MaxValue;
        int minus = 0;

        foreach (var row in matrix)
        {
            foreach (int val in row)
            {
                Total += Math.Abs(val);
                if (val < 0)
                    minus++;
                minAbsVal = Math.Min(minAbsVal, Math.Abs(val));
            }
        }
        if (minus % 2 != 0)
            Total -= 2 * minAbsVal;

        return Total;
    }
}