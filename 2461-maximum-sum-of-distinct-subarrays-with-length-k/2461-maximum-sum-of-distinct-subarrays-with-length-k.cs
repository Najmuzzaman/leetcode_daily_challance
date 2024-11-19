public class Solution {
    public long MaximumSubarraySum(int[] nums, int k) {
        int n = nums.Length;
        long sum = 0;
        Dictionary<int, int> mp = new Dictionary<int, int>();
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
            if(mp.ContainsKey(nums[i]))
                mp[nums[i]]++;
            else
                mp[nums[i]]=1;
        }
        long ans = 0;
        if(mp.Count==k)
            ans = sum;
        for(int i=k;i<n;i++)
        {
            sum+= nums[i];
            sum-=nums[i-k];

            if (mp[nums[i - k]] == 1)
                mp.Remove(nums[i - k]);
            else
                mp[nums[i - k]]--;

            if (mp.ContainsKey(nums[i]))
                mp[nums[i]]++;
            else
                mp[nums[i]] = 1;

            if (mp.Count == k)
                ans = Math.Max(sum, ans);
        }
        return ans;
    }
}