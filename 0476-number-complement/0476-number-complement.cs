public class Solution {
    public int FindComplement(int num) {
        int highestBit = 1 << (int)(Math.Log(num,2));
        int mask = (highestBit * 2) - 1;
        return num ^ mask;
    }
}