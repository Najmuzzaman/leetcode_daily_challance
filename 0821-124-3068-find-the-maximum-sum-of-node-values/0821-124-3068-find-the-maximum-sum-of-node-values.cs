public class Solution {
    public long MaximumValueSum(int[] nums, int k, int[][] edges) {
        long ans = nums.Sum(nums => (long)nums);
        
        long td = 0;
        long d;
        int positive_count = 0;
        long m = long.MaxValue;
        foreach(var p in nums)
        {
            d = (p^k) - p;
            if(d > 0)
            {
                td += d;
                positive_count++;
            }
            m = Math.Min(m, Math.Abs(d));
        }
        if(positive_count % 2 == 1)
            td = td - m;
        return ans + td;
    }
}