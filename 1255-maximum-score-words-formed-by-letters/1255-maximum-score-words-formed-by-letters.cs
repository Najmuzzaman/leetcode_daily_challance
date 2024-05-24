public class Solution {
    public int[] a = new int[26];
    public int[] b = new int[26];
    public int ans = 0;
    public int MaxScoreWords(string[] words, char[] letters, int[] score) 
    {
        foreach (char c in letters)
            a[ c-'a']++;
        dfs(0, words, score);
        return ans;
    }
    
    void dfs(int idx, string[] words, int[] score)
    {
        if (idx == words.Length)
        {
            int sc = 0;
            for (int i = 0; i < 26; i++) 
            {
                if (b[i] > a[i]) return;
                sc += score[i] * b[i];
            }
            ans = Math.Max(ans, sc);
            return;
        }
        
        dfs(idx + 1, words, score);
        
        foreach (char c in words[idx])
            b[c-'a']++;
        
        dfs(idx + 1, words, score);
        
        foreach (char c in words[idx]) 
            b[c-'a']--;
    }
}