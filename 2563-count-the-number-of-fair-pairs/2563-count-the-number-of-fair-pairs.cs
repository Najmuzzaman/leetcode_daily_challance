public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums);
        long  count = 0;
        
        for (int i = 0; i < nums.Length - 1; i++) {
            int lowIndex = LowerBound(nums, i + 1, nums.Length - 1, lower - nums[i]);
            int highIndex = UpperBound(nums, i + 1, nums.Length - 1, upper - nums[i]);
            count += highIndex - lowIndex + 1;
        }
        
        return count;
    }
    private int LowerBound(int[] nums, int start, int end, int target) {
        while (start <= end) {
            int mid = start + (end - start) / 2;
            if (nums[mid] < target) {
                start = mid + 1;
            } else {
                end = mid - 1;
            }
        }
        return start;
    }

    private int UpperBound(int[] nums, int start, int end, int target) {
        while (start <= end) {
            int mid = start + (end - start) / 2;
            if (nums[mid] <= target) {
                start = mid + 1;
            } else {
                end = mid - 1;
            }
        }
        return end;
    }
}