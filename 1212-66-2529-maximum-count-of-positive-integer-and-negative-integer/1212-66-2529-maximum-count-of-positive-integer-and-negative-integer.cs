public class Solution {
    public int MaximumCount(int[] nums) {
        int negativeCount = BinarySearch(nums, 0);
        int positiveCount = nums.Length - BinarySearch(nums, 1);
        return Math.Max(negativeCount, positiveCount);
    }

    private int BinarySearch(int[] nums, int target) {
        int leftIndex = 0, rightIndex = nums.Length - 1, position = nums.Length;
        
        while (leftIndex <= rightIndex) {
            int midIndex = (leftIndex + rightIndex) / 2;
            if (nums[midIndex] < target) {
                leftIndex = midIndex + 1;
            } else {
                position = midIndex;
                rightIndex = midIndex - 1;
            }
        }
        
        return position;
    }
}