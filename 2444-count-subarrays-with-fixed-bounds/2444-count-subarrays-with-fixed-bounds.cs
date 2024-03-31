public class Solution {
    public long CountSubarrays(int[] nums, int minK, int maxK) {
        long ans = 0;
        int s = -1, l = -1, r = -1;
        int n= nums.Length;
        for (int i = 0; i <n; ++i)
        {
            if (!(minK <= nums[i] && nums[i] <= maxK))
                s = i;

            if (nums[i] == minK) 
                l = i;

            if (nums[i] == maxK)
                r = i;
            
            ans += Math.Max(0, Math.Min(l, r) - s);
        }
        return ans;
    }
}