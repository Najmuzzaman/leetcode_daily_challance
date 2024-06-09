public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        int n = nums.Length;
        int sum=0;
        int cnt = 0;
        Dictionary<int,int> p= new Dictionary<int,int>();
        p[0]=1;
        for(int i=1;i<k;i++)
            p[i]=0;
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            int mod = (sum%k+k) % k;            
            cnt += p[mod];
            p[mod]++;
            
        }
        return cnt;
    }
}