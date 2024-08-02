public class Solution 
{
    public int MinSwaps(int[] nums) 
    {
        int n = nums.Length;
        int n1 = nums.Count(num => num == 1);
        int mswap = int.MaxValue;
        int cnt1 = 0;

        for (int l = 0, r = 0; r < n + n1; r++) 
        {
            cnt1 += nums[r % n];
            if (r - l + 1 > n1)
                cnt1 -= nums[l++ % n];

            if (r - l + 1 == n1)
                mswap = Math.Min(mswap, n1 - cnt1);
        }
        return mswap;
    }
}