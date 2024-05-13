public class Solution {
    public int MaximumEnergy(int[] energy, int k)
    {
        int n = energy.Length;
        int[] ans = new int[n];        
        int res = int.MinValue;
        for (int i = n - 1; i >= 0; i--) 
        {
            ans[i] = energy[i] + (i + k < n ? ans[i + k] : 0);
            res = Math.Max(res, ans[i]);
        }
        return res;
    }
}