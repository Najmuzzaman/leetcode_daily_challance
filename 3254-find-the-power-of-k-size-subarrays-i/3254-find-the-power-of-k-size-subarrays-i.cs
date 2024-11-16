public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        int n=nums.Length;
        int presum = 0;
        int[] ans = new int[n-k+1];
        for (int i = 1; i < k; i++)
        {
            if (nums[i] > nums[i - 1]  && (nums[i] - nums[i - 1])==1)
                presum += 1;
            else
                presum = 0;
        }
        if (presum == k - 1)
            ans[0] = nums[k - 1];
        else
            ans[0] = -1;
        for (int i = k; i < n; i++)
        {
            if (nums[i] > nums[i - 1] && (nums[i] - nums[i - 1]) == 1)
                presum += 1;
            else
                presum = 0;

            if (presum >= k - 1)
                ans[i-k+1] = nums[i];
            else
                ans[i - k + 1] = -1;
        }
        return ans;
    }
}