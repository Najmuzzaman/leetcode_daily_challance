public class Solution {
    public int AppendCharacters(string s, string t) {
        int a = s.Length;
        int b = t.Length;
        
        int i = 0, j = 0;
        while (i < a && j < b) {
            if (s[i] == t[j]) j++;
            i++;
        }        
        return b - j;
    }
}