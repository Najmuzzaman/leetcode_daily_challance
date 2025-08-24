public class Solution {
    public int LongestSubarray(int[] nums) {
        int i=0,j=0;
        int n=nums.Length;
        int m=0;
        int count=0;
        while(j<n)
        {
            if(nums[j]==0)
                count++;
            
            while(count>1)
            {
                if(nums[i]==0)
                    count--;
                
                i++;
            }
            m=Math.Max(m,j-i);
            j++;
        }
        return m;
    }
}