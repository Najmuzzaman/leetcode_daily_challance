public class Solution {
    public int TakeCharacters(string s, int k) {
        int[] a= new int[3];
        foreach(char ch in s)
        {
            a[ch-'a']++;
        }
        if (a[0] < k || a[1] < k || a[2] < k)
            return -1;
        else
        {
            int n = a[0] + a[1] +a[2];
            int[] NowCount = new int[3];
            int j = 0;
            int maxWindowSize = 0;
            for (int i = 0; i < n; i++)
            {
                NowCount[s[i] - 'a']++;
                while (NowCount[0] > a[0] - k ||
                       NowCount[1] > a[1] - k ||
                       NowCount[2] > a[2] - k)
                {
                    NowCount[s[j] - 'a']--;
                    j++;
                }
                maxWindowSize = Math.Max(maxWindowSize, i - j + 1);
            }
            return n - maxWindowSize;
        }
    }
}