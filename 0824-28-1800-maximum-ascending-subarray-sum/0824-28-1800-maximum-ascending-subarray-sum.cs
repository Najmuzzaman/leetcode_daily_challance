public class Solution {
    public int MaxAscendingSum(int[] nums) {
        int ans = 0;
        int sum = nums[0];
        int n=nums.Length;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1])
                sum += nums[i];
            else 
            {
                ans = Math.Max(ans, sum);
                sum = nums[i];
            }
        }
        return Math.Max(ans, sum);
    }
}