public class Solution {
    public int MinBitFlips(int start, int goal) {
        int xor=start^goal;
        int ans = 0;
        while (xor > 0) {
            ans += xor & 1; 
            xor >>= 1;        
        }        
        return ans;
    }
}