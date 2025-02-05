public class Solution {
    public bool AreAlmostEqual(string s1, string s2) {
        int i=-1, j=-1;
        int cnt=0;
        int n=s1.Length;
        for(int k=0; k<n; k++){
            if(s1[k]!=s2[k]){
                cnt++;
                if(i==-1) i=k;
                else if(j==-1) j=k;
            }
        }

        if(cnt==0) return true;
        else if(cnt==2 && s1[i]==s2[j] && s1[j]==s2[i])
            return true;

        return false;
    }
}