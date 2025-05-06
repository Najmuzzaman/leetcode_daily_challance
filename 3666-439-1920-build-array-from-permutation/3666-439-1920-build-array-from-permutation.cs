public class Solution {
    public int[] BuildArray(int[] nums) {
        int n=nums.Length;
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
            result[i] = nums[nums[i]];
        return result;
    }
}