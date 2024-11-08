public class Solution {
    public int[] GetMaximumXor(int[] nums, int maximumBit) {
        int n = nums.Length;
        int maxVal = (1 << maximumBit) - 1;
        int[] answer = new int[n];
        
        int xorSum = 0;
        foreach (var num in nums)
            xorSum ^= num;
        

        for (int i = 0; i < n; i++) 
        {
            answer[i] = xorSum ^ maxVal;
            
            xorSum ^= nums[n - 1 - i];
        }
        
        return answer;
    }
}