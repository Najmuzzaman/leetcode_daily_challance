public class Solution {
    static List<string> ans = new List<string>();
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        string S = "";
        Dictionary<string, bool> d = new Dictionary<string, bool>();

        foreach (var word in wordDict)
        {
            d[word] = true;
        }

        ans.Clear();
        dfs(0, ref S, s, d);
        return ans;
    }
    
    public void dfs(int i, ref string S, string s, Dictionary<string, bool> d)
    {
        if (i >= s.Length)
        {
            ans.Add(S);
            return;
        }

        for (int j = i + 1; j <= i + 10 && j <= s.Length; j++)
        {
            string word = s.Substring(i, j - i);
            if (d.ContainsKey(word))
            {
                string oldSentence = S;

                if (string.IsNullOrEmpty(S))
                {
                    S = word;
                }
                else
                {
                    S += " " + word;
                }

                dfs(j, ref S, s, d);

                S = oldSentence; 
            }
        }
    }
}