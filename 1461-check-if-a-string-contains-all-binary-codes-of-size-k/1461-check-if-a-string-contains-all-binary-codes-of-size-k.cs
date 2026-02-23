public class Solution {
    public bool HasAllCodes(string s, int k) {
        int cur = 0, len = s.Length;
        int fullLen = (int)Math.Pow(2, k);
        int mask = (int)Math.Pow(2, k-1)-1;
        int maxSubLen = len-k+1;
        if(maxSubLen < fullLen)
            return false;
        HashSet<int> visited = new();
        for(int i = 0; i < len; i++)
        {
            int b = s[i]-'0';
            if(i >= k)
            {
                cur &= mask;
            }
            cur *= 2;
            cur += b;
            if(i >= k-1)
                visited.Add(cur);
        }

        return visited.Count == fullLen;
    }
}