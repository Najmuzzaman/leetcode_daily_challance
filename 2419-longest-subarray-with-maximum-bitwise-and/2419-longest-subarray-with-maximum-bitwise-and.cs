public class Solution {
    public int LongestSubarray(int[] nums) {
        int maxVal = nums.Max();
        int n = nums.Length;
        
        // Step 2: Find the longest subarray with bitwise AND equal to maxVal
        int longestLength = 0;
        int currentLength = 0;        
        for (int i = 0; i < n; i++) 
        {
            if (nums[i] == maxVal)
            {
                currentLength++;
                longestLength = (longestLength>currentLength?longestLength:currentLength);
            }
            else
                currentLength = 0;            
        }        
        return longestLength; 
    }
}