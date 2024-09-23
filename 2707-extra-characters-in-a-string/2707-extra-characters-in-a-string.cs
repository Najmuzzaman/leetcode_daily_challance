public class Solution {
    public int MinExtraChar(string s, string[] dictionary) {
        int n = s.Length;
        // dp[i] means the minimum extra characters when breaking up to index i
        int[] dp = new int[n + 1];
        
        // Initialize dp array with the worst case (each index i has i extra chars)
        for (int i = 0; i <= n; i++) {
            dp[i] = i;
        }
        
        // Process the string and try to minimize extra characters
        for (int i = 0; i < n; i++) {
            // If dp[i] is already optimized, check for dictionary words
            foreach (var word in dictionary) {
                int len = word.Length;
                if (i + len <= n && s.Substring(i, len) == word) {
                    // If a match is found, update the dp value for the end of the word
                    dp[i + len] = Math.Min(dp[i + len], dp[i]);
                }
            }
            // If no match, we just carry the previous extra char count + 1
            dp[i + 1] = Math.Min(dp[i + 1], dp[i] + 1);
        }
        
        // The final answer is the minimum extra characters for the entire string
        return dp[n];
    }
}