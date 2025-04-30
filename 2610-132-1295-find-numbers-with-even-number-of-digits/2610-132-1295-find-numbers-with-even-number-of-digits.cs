public class Solution {
    public int FindNumbers(int[] nums) {
        int ans = 0;
        int n=nums.Length;
        for(int i=0;i<n;i++)
        {
            if( (9 < nums[i] &&  nums[i] < 100) || (999 < nums[i] &&  nums[i] < 10000) || (nums[i] == 100000) )
                ans += 1;
        }
        return ans;
    }
}