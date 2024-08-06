public class Solution {
    public int MinimumPushes(string word) {
        int[] freq = new int[26];

        foreach (char a in word)
            freq[a - 'a']++;

        Array.Sort(freq, (a, b) => b.CompareTo(a));

        int sz = 0, push = 1, ans = 0;
        while (sz < 26 && freq[sz] != 0)
        {
            if (sz >= 8 && sz % 8 == 0)
                push++;
            ans += freq[sz] * push;
            sz++;
        }
        return ans;
    }
}