public class Solution {
    public int[] SortedSquares(int[] nums) {
        int n=nums.Length;
        for(int i=0;i<n;i++)
            nums[i]*=nums[i];
        Array.Sort(nums);
        return nums;
    }
}