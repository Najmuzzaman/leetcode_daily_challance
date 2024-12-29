public class Solution {
    public int NumWays(string[] words, string target) {
        int n = words[0].Length;
        int m = target.Length;
        int mod = 1000000007;
        int[] dp = new int[m+1];
        dp[0] = 1;        
        int[,] count = new int[n,26];
        foreach (string word in words) 
            for (int i = 0; i < n; i++) 
                count[i,word[i] - 'a']++;
            
        
        
        for (int i = 0; i < n; i++) 
            for (int j = m-1; j >= 0; j--) {
                dp[j+1] += (int)((long)dp[j] * count[i,target[j] - 'a'] % mod);
                dp[j+1] %= mod;
            }
        
        
        return dp[m];
    }
}