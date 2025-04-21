public class Solution {
    public int NumberOfArrays(int[] differences, int lower, int upper) {
        long sum = 0, ma = 0, mi = 0;
        foreach (int i in differences) {
            sum += i;
            ma = Math.Max(ma, sum);
            mi = Math.Min(mi, sum);
        }
        return (int)Math.Max(0, upper - lower - ma + mi + 1);
    }
}