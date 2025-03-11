public class Solution {
    public int NumberOfSubstrings(string s) {
         int n = s.Length ;
        int start = 0 ;
        int[] freq=new int[3];
        int ans = 0 ;
        for(int i = 0 ; i < n ; i++)
        {
            freq[ s[i]-'a']++;
            if(freq[0] > 0 && freq[1]>0 && freq[2]>0 )
            {
                while(freq[0] > 0 && freq[1]>0 && freq[2]>0)
                {
                    ans += n - i ;
                    freq[s[start]-'a']--;
                    start++;
                }
            }
        }
        return ans ;
    }
}