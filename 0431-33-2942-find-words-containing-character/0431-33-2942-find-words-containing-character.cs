public class Solution {
    public IList<int> FindWordsContaining(string[] words, char x) {
        List<int> ans = new List<int>();
        int n=words.Length;
        for (int i = 0; i< n; i++)
            if (words[i].Contains(x))
                ans.Add(i);
        return ans;  
    }
}