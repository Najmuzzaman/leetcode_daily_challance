public class Solution {
    public int LongestSquareStreak(int[] nums) {
        int n=nums.Length;
        bool[] f = new bool[100009];
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            f[nums[i]]=true;
            max= Math.Max(max, nums[i]);
        }
        int ans = 0;
        for (int i = 2; i <= max; i++)
        {
            int res = 0;
            long ins = i;
            while(f[ins]==true)
            {
                f[ins]=false;
                ins = ins*ins;
                res++;
                if (ins > 100000)
                    break;
            }
            if(res>=2)
                ans = Math.Max(ans, res);
        }
        return ans==0?-1:ans;
    }
}