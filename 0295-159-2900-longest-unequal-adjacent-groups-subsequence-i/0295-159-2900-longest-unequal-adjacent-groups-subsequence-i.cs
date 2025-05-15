public class Solution {
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) {
        int ind=groups[0];
        IList<string> ans= new List<string>();
        ans.Add(words[0]);
        int n=words.Length;
        for(int i=1;i<n;i++)
        {
            if(groups[i]!=ind)
                ans.Add(words[i]);
            ind=groups[i];
        }
        return ans;
    }
}