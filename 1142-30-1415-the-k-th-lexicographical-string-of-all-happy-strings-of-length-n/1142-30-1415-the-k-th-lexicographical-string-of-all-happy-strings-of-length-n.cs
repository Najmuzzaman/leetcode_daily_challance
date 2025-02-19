public class Solution {
    private string s = "abc";
    private string ans = "";
     private void dfs(string cur, int n, int k, ref int count)
    {
        if (count == k) return;
        if (cur.Length == n)
        {
            ans = cur;
            count++;
            return;
        }
        
        foreach (char ch in s)
        {
            if (cur.Length > 0 && ch == cur[^1]) continue;
            dfs(cur + ch, n, k, ref count);
        }
    }
    public string GetHappyString(int n, int k) {
        int count = 0;
        dfs("", n, k, ref count);
        return count == k ? ans : "";
    }
}