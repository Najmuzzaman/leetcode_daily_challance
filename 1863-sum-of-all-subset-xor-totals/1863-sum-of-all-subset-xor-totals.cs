public class Solution {
    public int SubsetXORSum(int[] nums) {
        int ans = 0;
        int n=nums.Length;
        foreach (int num in nums) 
            ans |= num;
        
        return ans << (n - 1);
    }
}