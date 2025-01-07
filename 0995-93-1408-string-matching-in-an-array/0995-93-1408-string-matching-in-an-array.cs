public class Solution {
    public IList<string> StringMatching(string[] words) {
        IList<string> ans = new List<string>();
        foreach (var word in words)
        {
            foreach (var word2 in words)
            {
                if (word != word2 && word2.Contains(word))
                {
                    ans.Add(word);
                    break;
                }
            }
        }
        return ans;
    }
}