public class Solution {
    public int MinSwaps(string s) {
        int ans = 0;
        int n=s.Length;
        for (int i = 0; i < n; i++)
        {
            char ch = s[i];
            if (ch == '[') 
                ans++;
            else if (ans > 0) 
                ans--;
        }
        return (ans + 1) / 2; 
    }
}