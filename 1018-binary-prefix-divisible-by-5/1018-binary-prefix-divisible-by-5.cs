public class Solution {
    public IList<bool> PrefixesDivBy5(int[] nums) {
        int cur = 0;
        int n=nums.Length;
         bool[] ans = new bool[n];
        for(int i = 0; i < n; i += 1)
        {
            cur *= 2;
            cur += nums[i];
            ans[i] = cur % 5 == 0;
            cur %= 5;
        }

        return ans;
    }
}