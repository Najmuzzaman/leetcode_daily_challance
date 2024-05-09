public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) 
    {
        Array.Sort(happiness);
        int dec = 0;
        int n=happiness.Length;
        long ans=0;
        for(int i=n-1;i>=n-k;i--)
        {
            ans += Math.Max(0,happiness[i]-dec);
            dec++;
        }
        return ans;
    }
}