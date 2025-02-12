public class Solution {
    public int MaximumSum(int[] nums) {
       int n = nums.Length;
        Dictionary<int, List<int>> dp = new Dictionary<int, List<int>>();
        for (int i=0;i<n;i++)
        {
            int sum = digitsum(nums[i]);
            if(dp.ContainsKey(sum))
                dp[sum].Add(nums[i]);
            else
                dp.Add(sum, new List<int> { nums[i] });                
        }
        int max = -1;
        foreach(var item in dp)
        {
            if (item.Value.Count > 1)
            {
                item.Value.Sort();
                max = Math.Max(max, item.Value[item.Value.Count - 1] + item.Value[item.Value.Count - 2]);
            }
        }
        return max; 
    }
    private int digitsum(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }
}