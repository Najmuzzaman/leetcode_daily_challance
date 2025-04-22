public class Combinations
{
    private long[] fact;
    private long[] invFact;
    private long M;  

    public Combinations(int n, long mod) {
        M = mod;
        fact = new long[n + 1];
        invFact = new long[n + 1];
        fact[0] = 1;
        invFact[0] = 1;
        for (int i = 1; i <= n; i++) {
            fact[i] = (fact[i - 1] * i) % M;
            invFact[i] = Power(fact[i], M - 2);
        }
    }

    private long Power(long baseValue, long exp) {
        long res = 1;
        baseValue %= M;
        while (exp > 0) {
            if ((exp & 1) == 1) res = (res * baseValue) % M;
            baseValue = (baseValue * baseValue) % M;
            exp >>= 1;
        }
        return res;
    }

    public long NCr(int n, int r) {
        if (r < 0 || r > n) return 0;
        long num = fact[n];
        long den = (invFact[r] * invFact[n - r]) % M;
        return (num * den) % M;
    }
}
public class Solution {
    private const int MOD = 1_000_000_007;
    public int IdealArrays(int n, int maxValue) {
        var comb = new Combinations(n, MOD);
        var dp = new long[maxValue + 1];
        long totalAns = maxValue;

        for (int i = 1; i <= maxValue; i++) {
            dp[i] = 1;
        }

        int kLimit = Math.Min(n, 16);

        for (int k = 2; k <= kLimit; k++) {
            var nextDp = new long[maxValue + 1];
            for (int j = 1; j <= maxValue; j++) {
                if (dp[j] == 0) continue;
                for (long i = 2L * j; i <= maxValue; i += j) {
                    nextDp[(int)i] = (nextDp[(int)i] + dp[j]) % MOD;
                }
            }

            long count = 0;
            for (int i = 1; i <= maxValue; i++) {
                count = (count + nextDp[i]) % MOD;
            }

            if (count == 0) break;

            long factor = comb.NCr(n - 1, k - 1);
            totalAns = (totalAns + count * factor % MOD) % MOD;

            dp = nextDp;
        }

        return (int)totalAns;
    }
}