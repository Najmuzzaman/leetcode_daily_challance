public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        if (k <= 1) {
            return 0;
        }
        int n = nums.Length;
        int count = 0;
        int product = 1;
        int left = 0;

        for (int right = 0; right < n; right++) {
            product *= nums[right];
            
            while (product >= k) {
                product /= nums[left];
                left++;
            }
            
            count += right - left + 1;
        }

        return count;
    }
}