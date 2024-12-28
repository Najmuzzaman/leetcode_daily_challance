public class Solution {
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k) {
        int n = nums.Length;
        int[] sums = new int[n];
        int[] l = new int[n];
        int[] r = new int[n];

        int sum = 0;
        for (int i = 0; i < n; ++i)
        {
            sum += nums[i];
            if (i >= k)
                sum -= nums[i - k];
            if (i >= k - 1)
                sums[i - k + 1] = sum;
        }
        int maxIndex = 0;
        for (int i = 0; i <n-k+1; ++i)
        {
            if (sums[i] > sums[maxIndex])
                maxIndex = i;
            l[i] = maxIndex;
        }

        maxIndex = n - k;
        for (int i = n - k; i >= 0; --i)
        {
            if (sums[i] >= sums[maxIndex])
                maxIndex = i;
            r[i] = maxIndex;
        }

        int[] ans = { -1, -1, -1 };
        for (int i = k; i < n - 2*k+1; ++i)
        {
            if (ans[0] == -1 || sums[ans[0]] + sums[ans[1]] + sums[ans[2]] <
                            sums[l[i - k]] + sums[i] + sums[r[i + k]])
            {
                ans[0] = l[i - k];
                ans[1] = i;
                ans[2] = r[i + k];
            }
        }
        return ans;
    }
}