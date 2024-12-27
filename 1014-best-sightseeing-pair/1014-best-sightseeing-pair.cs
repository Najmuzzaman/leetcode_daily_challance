public class Solution {
    public int MaxScoreSightseeingPair(int[] values) {
        int n=values.Length;
        int ans=0;
        int first=values[0];
        for(int i=1;i<n;i++)
        {
            int second=values[i]-i;
            ans=Math.Max(ans,first+second);
            
            int f=values[i]+i;
            first=Math.Max(first,f);
            
        }
        return ans;
    }
}