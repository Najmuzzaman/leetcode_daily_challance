public class Solution {
    public int MinimumRecolors(string blocks, int k) {
        int n=blocks.Length;
        int ans = 0;
        int black = 0;
        int white = 0;
        int i = 0;
        for(; i < k; i++)
        {
            if (blocks[i] == 'B')
                black++;            
            else
                white++;
        }
        ans = white;
        for(;i<n;i++)
        {
            if (blocks[i] == 'B')
                black++;
            else
                white++;
            
            if (blocks[i - k] == 'B')
                black--;
            else
                white--;
            
            ans = Math.Min(ans, white);
        }
        return ans;
    }
}