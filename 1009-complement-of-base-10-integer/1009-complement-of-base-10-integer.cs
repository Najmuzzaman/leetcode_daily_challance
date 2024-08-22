public class Solution {
    public int BitwiseComplement(int n) {
        int highestBit = 1 << (int)(Math.Log(n,2));
        int mask = (highestBit * 2) - 1;
        return n ^ mask;
    }
}