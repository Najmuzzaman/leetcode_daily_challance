public class Solution {
    private int maxCount = 0;
    
    public int MaxUniqueSplit(string s) {
        List<string> seen = new List<string>();
        maxCount = 0;
        dfs(s, 0, seen, 0);
        return maxCount;
    }

    private void dfs(string s, int start, List<string> seen, int count) 
    {
        if (count + (s.Length - start) <= maxCount) return;
        if (start == s.Length) 
        {
            maxCount = Math.Max(maxCount, count);
            return;
        }
        for (int end = start + 1; end <= s.Length; end++) {
            string substring = s.Substring(start, end - start);
            
            if (!seen.Contains(substring)) {
                seen.Add(substring);
                dfs(s, end, seen, count + 1);
                seen.Remove(substring);
            }
        }
    }
}