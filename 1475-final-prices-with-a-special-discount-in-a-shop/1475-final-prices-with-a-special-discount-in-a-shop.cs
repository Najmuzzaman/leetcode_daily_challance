public class Solution {
    public int[] FinalPrices(int[] prices) {
        int n=prices.Length;
        int[] ans=new int[n];
        for(int i=0;i<n;i++)
        {
            ans[i]=prices[i];
            for(int j=i+1;j<n;j++)
            {
                if(prices[j]<=prices[i])
                {
                    ans[i]=prices[i]-prices[j];
                    break;
                }
            }
        }
        return ans;
    }
}