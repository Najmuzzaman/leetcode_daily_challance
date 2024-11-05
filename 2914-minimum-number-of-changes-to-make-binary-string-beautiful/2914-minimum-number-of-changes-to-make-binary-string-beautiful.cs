public class Solution {
    public int MinChanges(string s) {
        int n=s.Length;
        int o=0,z=0;
        for(int i=1;i<n;i+=2)
            if((s[i]=='0' && s[i-1]=='1') || (s[i]=='1' && s[i-1]=='0') ) z++;
        
        return z;
    }
}