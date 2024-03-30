public class Solution {
    public int FindMostK(int n, int k, int[] nums)
    {
        int ans = 0;
        int l = 0, r = 0;
        Dictionary<int, int> mp = new Dictionary<int, int>();
        while (r < n)
        {
            if (!mp.ContainsKey(nums[r]))
                mp[nums[r]] = 1;
            else
                mp[nums[r]]++;

            while (mp.Count > k && l <= r)
            {
                mp[nums[l]]--;
                if (mp[nums[l]] == 0)
                {
                    mp.Remove(nums[l]);
                }
                l++;
            }
            ans += r - l + 1;
            r++;
        }
        return ans;
    }
    public int SubarraysWithKDistinct(int[] nums, int k) {
        int n = nums.Length;
        int a = FindMostK(n, k, nums);
        int b = FindMostK(n, k -1, nums);
        return a -b;
    }
}