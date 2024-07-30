public class Solution {
    public int MinimumDeletions(string s) 
    {
        int n = s.Length;
        int B_pre = s[0] == 'b' ? 1 : 0;
        int A_suf = s.Count(c => c == 'a'); // Count 'a' in s
        int cnt = B_pre + A_suf - 1;
        
        for (int i = 1; i < n; i++) 
        {
            B_pre += (s[i] == 'b' ? 1 : 0);
            A_suf -= (s[i - 1] == 'a' ? 1 : 0);
            cnt = Math.Min(cnt, B_pre + A_suf - 1);
        }
        
        return cnt;
    }
}