public class Solution {
     public Boolean isPrefixAnsSuffix(string a, string b)
    {
        if (b.StartsWith(a) && b.EndsWith(a))
            return true;
        return false;
    }
    public int CountPrefixSuffixPairs(string[] words) {
        int ans = 0;
        int n=words.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                if (isPrefixAnsSuffix(words[i], words[j]))
                    ans++;
            }
        }
        return ans;
    }
}