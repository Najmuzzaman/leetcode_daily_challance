public class Solution {
    public string ShiftingLetters(string s, int[][] shifts) {
        int n = s.Length;
        int[] v = new int[n + 1];

        foreach (var shift in shifts) 
        {
            int l = shift[0], r = shift[1];
            int c = shift[2];
            v[l] += (2 * c - 1);
            if (r + 1 < v.Length) 
                v[r + 1] -= (2 * c - 1);
            
        }

        int a = 0;
        char[] chars = s.ToCharArray();
        for (int i = 0; i < n; i++) 
        {
            a += v[i];
            int p = (chars[i] - 'a' + a % 26 + 26) % 26;
            chars[i] = (char)('a' + p);
        }

        return new string(chars);
    }
}