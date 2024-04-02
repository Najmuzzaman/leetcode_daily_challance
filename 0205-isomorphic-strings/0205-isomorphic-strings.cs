public class Solution {
    public bool IsIsomorphic(string s, string t) {
        Dictionary<char, char> mp = new Dictionary<char, char>();
        Dictionary<char, char> mp1 = new Dictionary<char, char>();
        int n=s.Length;
        for(int i=0;i<n;i++)
        {
            char a=s[i];
            char b=t[i];
            if(mp.ContainsKey(a))
            {
                if(mp[a]!=b) return false;
            }
            mp[a]=b;
            if(mp1.ContainsKey(b))
            {
                if(mp1[b]!=a) return false;
            }
            mp1[b]=a;                
        }
        return true;
    }
}