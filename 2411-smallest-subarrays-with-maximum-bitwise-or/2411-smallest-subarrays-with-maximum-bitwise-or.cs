public class Solution {
    public int[] SmallestSubarrays(int[] nums) {
        int[] result = new int[nums.Length];
        int n=nums.Length;
        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            result[i] = 1;
            for (int j = i - 1; j >= 0 && (nums[j] | num) != nums[j]; j--)
            {
                nums[j] |= num;
                result[j] = i - j + 1;
            }
        }
        return result;
    }
}