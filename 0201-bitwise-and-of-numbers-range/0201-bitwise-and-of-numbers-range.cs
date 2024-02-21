public class Solution {
    public int RangeBitwiseAnd(int left, int right) {
        int result = 0;
        // Find the common bits from MSB
        while (left > 0 && left != right) {
            left >>= 1;
            right >>= 1;
            result++;
        }

        // Shift back to get the final result
        return left << result;
    }
}