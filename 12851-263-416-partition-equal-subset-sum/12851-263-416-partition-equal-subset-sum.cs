public class Solution {
    Dictionary<string, bool> dp = new ();
    bool dfs(int[] nums, int index, int currentSum) {
        string key = index.ToString() + "-" + currentSum.ToString();
        if(dp.ContainsKey(key)) return dp[key];
        bool result = false;
        if (currentSum == 0)
            result = true;
        else if (index >= nums.Length || currentSum < 0)
            result = false;
        else 
        {
            result = dfs(nums, index + 1, currentSum - nums[index]) || dfs(nums, index + 1, currentSum);
        }
        dp[key] = result;
        return result;
    }
    public bool CanPartition(int[] nums) {
        int sum = nums.Sum();
        if (sum % 2 != 0) return false;
        return dfs(nums, 0, sum / 2);
    }
}