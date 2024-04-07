public class Solution {
    public bool CheckValidString(string s) {
        int l = 0, r = 0;
        
        foreach(char c in s) 
        {
            l += c == '(' ? 1 : -1;
            r += c == ')' ? -1 : 1;
            
            if (r < 0)
                break;
            
            l = Math.Max(l, 0);
        }
        return l == 0;
    }
}