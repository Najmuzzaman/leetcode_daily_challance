public class Solution {
    public int LongestNiceSubarray(int[] nums) {
        int ans = 1;
        int n=nums.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int res = 1;
            int te = nums[i];
            for (int j = i + 1; j < n; j++)
            {
                if ((te & nums[j]) == 0)
                {
                    res++;
                    if (res > ans)
                    {
                        ans = res;
                    }
                }
                else
                {
                    break;
                }
                te = te | nums[j];
            }
        }
        return ans; 
    }
}