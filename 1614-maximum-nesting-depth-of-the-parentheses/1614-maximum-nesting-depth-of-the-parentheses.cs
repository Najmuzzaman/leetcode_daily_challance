public class Solution {
    public int MaxDepth(string s) {
        int ans = 0;
        int dpt = 0;
        
        foreach (char c in s) {
            if (c == '(') {
                dpt++;
                ans = Math.Max(ans, dpt);
            } else if (c == ')') {
                dpt--;
            }
        }        
        return ans;
    }
}