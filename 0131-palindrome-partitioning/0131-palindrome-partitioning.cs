public class Solution {
    private int[][] dp;
    private IList<IList<string>> ans;
    private int n;
    public IList<IList<string>> Partition(string s) {
        n = s.Length;
        if (n == 1) return new List<IList<string>> { new List<string> { s } };

        dp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[n];
            for (int j = 0; j < n; j++) {
                dp[i][j] = -1;
            }
        }
        ans = new List<IList<string>>();
        List<string> valids = new List<string>();
        dfs(s, 0, valids);
        return ans;
    }
     private void dfs(string s, int start, List<string> valids) {
        if (start >= n) {
            ans.Add(new List<string>(valids));
            return;
        }
        for (int end = start; end < n; end++) {
            if (isPalindrome(s, start, end)) {
                valids.Add(s.Substring(start, end - start + 1));
                dfs(s, end + 1, valids);
                valids.RemoveAt(valids.Count - 1); // backtracking
            }
        }
    }
    
    private bool isPalindrome(string s, int l, int r){
        if (dp[l][r] != -1) {
            return dp[l][r] == 1;
        }
        while (l < r) {
            if (s[l] != s[r]) {
                dp[l][r] = 0;
                return false;
            }
            l++;
            r--;
        }
        dp[l][r] = 1;
        return true;
    }
    
   
}