public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        if (nums.Length == 1)
            return 0;
    
        Array.Sort(nums, (First, Second) => Second - First);
        int ans = int.MaxValue;

        for (int i = 0; i <= nums.Length - k; i++)
            ans = Math.Min(ans, nums[i] - nums[i + k - 1]);

        return ans;
    }
}