public class Solution {
    public int MaxOperations(string s) {
       int ans = 0;
        int ones = 0;
        bool prevZero = false;

        foreach (char c in s) 
        {
            if (c == '1') 
            {
                ones++;
                prevZero = false; // reset zero streak
            } 
            else if (!prevZero) {
                // first zero after one or start
                ans += ones;
                prevZero = true;
            }
        }
        return ans;
    }
}