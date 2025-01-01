public class Solution {
    public int MaxScore(string s) {
        int n = s.Length;
        int one = 0;
        int zero = s[0]=='0'?1:0;
        int ans = zero; 
        for (int i = 1; i < n-1; i++)
        {
            if (s[i] == '0')
            {
                zero++;
            }
            else
            {
                one++;
                zero--;
            }
            if (ans < zero)
                ans = zero;
        }
        one += (s[n - 1] == '1' ? 1 : 0);
        
        return ans+one;
    }
}