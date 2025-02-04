public class Solution {
    public int LongestMonotonicSubarray(int[] nums) {
        int n=nums.Length;
        if (n==0)
            return 0;
        int maxLen=1;
        int currentLen=1;
        bool increasing=false;
        bool decreasing=false;
        for (int i=1;i<n;i++) 
        {
            if (nums[i]>nums[i-1])
            {
                if (decreasing)
                { 
                    currentLen = 1;
                    decreasing = false;
                }
                increasing = true;
                currentLen++;
            } 
            else if (nums[i] < nums[i-1])
            { 
                if(increasing)
                { 
                    currentLen = 1;
                    increasing = false;
                }
                decreasing = true;
                currentLen++;
            } 
            else 
            { 
                currentLen = 1;
                increasing = false;
                decreasing = false;
            }
            maxLen = Math.Max(maxLen, currentLen); 
        }
        return maxLen;
    }
}