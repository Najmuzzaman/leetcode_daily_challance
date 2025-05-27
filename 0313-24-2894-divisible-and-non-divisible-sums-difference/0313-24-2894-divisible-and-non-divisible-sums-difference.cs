public class Solution {
    public int DifferenceOfSums(int n, int m) {
        int nc2 = (n * (n + 1)) / 2;
        int d = n / m;
        int s = (d * (d + 1)) / 2 * m;

        return nc2 - 2*s;
    }
}