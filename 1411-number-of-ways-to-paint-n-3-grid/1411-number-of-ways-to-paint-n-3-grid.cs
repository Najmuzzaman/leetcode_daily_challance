public class Solution {
    public int NumOfWays(int n) {
        const long mod = 1000000007;
        long a = 6, b = 6;
        for (int i = 2; i <= n; i++)
        {
            long newA = (2 * a + 2 * b) % mod;
            long newB = (2 * a + 3 * b) % mod;

            a = newA;
            b = newB;
        }

        return (int)((a + b) % mod);
    }
}