public class Solution {
    public string FirstPalindrome(string[] words) {        
        int n = words.Length;
        for(int i=0;i<n;i++)
        {
            string s = words[i];
            int slen=s.Length;
            bool parim=true;
            int len = slen / 2;
            for (int j=0; j<len && parim; j++)
            {
                if (s[j] != s[slen-j-1])
                {
                    parim = false;
                }
            }
            if (parim)
            {
                return s;
            }
        }
        return "";
    }
}