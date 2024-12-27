public class Solution {
    public int MaxScoreSightseeingPair(int[] values) {
        int n=values.Length;
        int ans=0;
        int first=values[0];
        for(int i=1;i<n;i++)
        {
            ans=Math.Max(ans,first+values[i]-i);
            first=Math.Max(first,values[i]+i);            
        }
        return ans;
    }
}