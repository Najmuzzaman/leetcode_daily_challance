public class Solution {
    public IList<string> CommonChars(string[] words) {
        int n = words.Length;
        int[][] c = new int[n][];
        for (int i = 0; i < n; i++)
        {
            c[i] = new int[30];
            string s = words[i];
            foreach (char s2 in s)
                c[i][s2 - 'a']++;
        }
        List<string> ans = new List<string>();
        for (int j = 0; j <= 26; j++)
        {
            int ma = int.MaxValue;
            for (int i = 0; i < n; i++)
                ma = Math.Min(ma, c[i][j]);
            char a = ((char)(97+j));
            while (ma>0)
            {
                ans.Add(a.ToString());
                ma--;
            }
        }
        return ans;
    }
}