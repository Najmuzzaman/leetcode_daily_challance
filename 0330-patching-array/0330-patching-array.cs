public class Solution {
    public int MinPatches(int[] nums, int n) {
        long m = 1;
        int p = 0;
        int i = 0;
        int l= nums.Length;
        while (m <= n) {
            if (i < l && nums[i] <= m) 
            {
                m += nums[i];
                i++;
            } 
            else
            {
                m += m;
                p++;
            }
        }

        return p;
    }
}