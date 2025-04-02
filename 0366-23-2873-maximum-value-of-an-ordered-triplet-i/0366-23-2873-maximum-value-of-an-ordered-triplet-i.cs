public class Solution {
    public long MaximumTripletValue(int[] nums) {
        int n=nums.Length;
        long ans=0;
        if(n == 3)
        {
            ans = ((long)nums[0] - nums[1])*nums[2];
            return ans > 0 ? ans : 0;
        }

        for(int i = 0; i < n - 2; i++)
        {
            for(int j = i + 1; j < n - 1;  j++)
            {
                long subtract = nums[i] - nums[j];

                if(subtract <= 0)
                    break;

                for(int k = j + 1; k < n; k++)
                {
                    ans = Math.Max(ans, (long)subtract*nums[k]);
                }
            }
        }
        return ans;
    }
}