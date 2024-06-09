public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        int n = nums.Length;
        int sum=0;
        int cnt = 0;
        Dictionary<int,int> p= new Dictionary<int,int>();
        p[0]=1;
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            int mod = sum % k;
            if (mod < 0)
                mod += k;
            if (p.ContainsKey(mod))
            {
                cnt += p[mod];
                p[mod]++;
            }
            else
                p[mod]=1;
        }
        return cnt;
    }
}