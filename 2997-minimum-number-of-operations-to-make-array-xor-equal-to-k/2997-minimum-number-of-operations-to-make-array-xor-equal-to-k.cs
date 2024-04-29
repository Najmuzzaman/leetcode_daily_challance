public class Solution {
    public int MinOperations(int[] nums, int k) {
        int ops = 0;
        int xor = 0;
        
        foreach (int num in nums) {
            xor ^= num;
        }
        
        int targetXor = xor ^ k;
        
        int ans = 0;
        while(targetXor!=0){
            ans++;
            targetXor = (targetXor & (targetXor -1));
        }

        return ans;
    }
}