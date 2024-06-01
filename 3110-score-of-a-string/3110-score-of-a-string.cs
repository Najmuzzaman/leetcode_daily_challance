public class Solution {
    public int ScoreOfString(string s) {
        int n=s.Length;
        int ans=0;
        for(int i=1;i<n;i++)
            ans+=Math.Abs(s[i-1]-s[i]);
        
        return ans;
    }
}