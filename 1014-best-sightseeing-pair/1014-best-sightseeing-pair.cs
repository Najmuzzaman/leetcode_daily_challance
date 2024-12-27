public class Solution {
    public int MaxScoreSightseeingPair(int[] values) {
        int n=values.Length;
        int ans=0;
        int first=values[0];
        for(int i=1;i<n;i++)
        {
            if(ans<(first+values[i]-i))
                ans=first+values[i]-i;
            if(first<(values[i]+i))
                first=values[i]+i;            
        }
        return ans;
    }
}