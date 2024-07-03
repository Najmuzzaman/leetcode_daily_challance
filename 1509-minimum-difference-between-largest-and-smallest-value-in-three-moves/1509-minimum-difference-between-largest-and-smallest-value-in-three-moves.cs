public class Solution {
    public int MinDifference(int[] nums) {
        int n = nums.Length;
        if( n <= 4) {
            return 0;
        }
        Array.Sort(nums);
        int ans = nums[n-1] - nums[0];
        for(int i = 0; i <= 3; i++)
            ans = Math.Min(ans, nums[n - 3 + i - 1] - nums[i]);
        return ans;
    }
}