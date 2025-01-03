public class Solution {
    public int WaysToSplitArray(int[] nums) {
        int n = nums.Length;
        int ans = 0;
        long[] prefix=new long[n];
        prefix[0]=nums[0];
        for (int i = 1; i < n; i++)
            prefix[i] = prefix[i - 1] + nums[i] ;

        for(int i=0; i<n-1; i++) 
            if(prefix[i] >= prefix[n-1]-prefix[i]) 
                ans++;
        return ans;
    }
}