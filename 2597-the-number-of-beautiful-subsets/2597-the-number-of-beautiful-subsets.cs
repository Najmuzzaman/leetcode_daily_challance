public class Solution {
     public int dfs(int[] nums, int idx, int k, Dictionary<int, int> mp) 
     {
        if (idx == nums.Length) return 1;

        int taken = 0;
        if (!mp.ContainsKey(nums[idx] - k) && !mp.ContainsKey(nums[idx] + k)) {
            if (!mp.ContainsKey(nums[idx])) mp[nums[idx]] = 0;
            mp[nums[idx]]++;
            taken = dfs(nums, idx + 1, k, mp);
            mp[nums[idx]]--;
            if (mp[nums[idx]] == 0) mp.Remove(nums[idx]);
        }

        int notTaken = dfs(nums, idx + 1, k, mp);

        return taken + notTaken;
    }


    public int BeautifulSubsets(int[] nums, int k) {
        var mp = new Dictionary<int, int>();
        int ans = dfs(nums, 0, k, mp);
        return ans - 1;
    }
}