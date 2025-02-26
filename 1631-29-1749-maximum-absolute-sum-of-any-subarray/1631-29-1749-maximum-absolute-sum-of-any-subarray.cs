public class Solution {
    public int MaxAbsoluteSum(int[] nums) {
        int minP = 0, maxP = 0;
        int p = 0;

        for (int i = 0; i < nums.Length; i++) 
        {
            p += nums[i];

            minP = Math.Min(minP, p);
            maxP = Math.Max(maxP, p);
        }

        return maxP - minP;
    }
}