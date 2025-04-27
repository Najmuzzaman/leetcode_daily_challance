public class Solution {
    public int CountSubarrays(int[] nums) {
        int n=nums.Length;
        int ans=0;
        for (int i = 0 ; i + 2 < n; i++)
            if (2 * (nums[i] + nums[i + 2]) == nums[i + 1]) 
                ans++;
        return ans;
    }
}