public class Solution {
    public int RangeBitwiseAnd(int left, int right) {
        int shift = 0;
        // Find the common prefix (MSB) of left and right
        while (left < right) {
            left >>= 1;
            right >>= 1;
            shift++;
        }
        // Shift left by the common prefix to get the final result
        return left << shift;
    }
}