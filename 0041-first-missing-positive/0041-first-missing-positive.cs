public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;

        // Place each number in its correct position
        for (int i = 0; i < n; i++)
        {
            while (nums[i] >= 1 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
            {
                int temp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
            }
        }

        // Iterate to find the smallest positive integer that is not present
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }

        // If all numbers from 1 to n are present, return n + 1
        return n + 1;
    }
}