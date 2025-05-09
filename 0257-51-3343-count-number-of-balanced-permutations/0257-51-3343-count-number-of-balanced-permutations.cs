public class Solution {
    const long MOD = 1_000_000_007;
    public int CountBalancedPermutations(string num) {
        
    int n = num.Length;
        int[] freq = new int[10];
        foreach (char ch in num) {
            freq[ch - '0']++;
        }

        long totalSum = 0;
        for (int d = 0; d < 10; d++) {
            totalSum += d * (long)freq[d];
        }

        if (totalSum % 2 != 0) return 0;
        long target = totalSum / 2;
        int Neven = (n % 2 == 0) ? n / 2 : (n / 2 + 1);
        int Nodd = n - Neven;

        return DPSolution(freq, Neven, Nodd, (int)target, n);
    }

    private int DPSolution(int[] freq, int Neven, int Nodd, int target, int n) {
        (long[] fact, long[] invFact) = PrecomputeFactorials(n + 1);

        long[,,] dp = new long[11, Neven + 1, target + 1];
        dp[0, 0, 0] = 1;

        for (int d = 0; d < 10; d++) {
            int cnt = freq[d];
            for (int j = 0; j <= Neven; j++) {
                for (int s = 0; s <= target; s++) {
                    long cur = dp[d, j, s];
                    if (cur == 0) continue;

                    int max_x = Math.Min(cnt, Neven - j);
                    for (int x = 0; x <= max_x; x++) {
                        int new_j = j + x;
                        int new_sum = s + d * x;
                        if (new_sum <= target) {
                            long mult = invFact[x] * invFact[cnt - x] % MOD;
                            dp[d + 1, new_j, new_sum] = (dp[d + 1, new_j, new_sum] + cur * mult % MOD) % MOD;
                        }
                    }
                }
            }
        }

        long res = dp[10, Neven, target];
        long result = res * fact[Neven] % MOD * fact[Nodd] % MOD;
        return (int)result;
    }

    private (long[], long[]) PrecomputeFactorials(int n) {
        long[] fact = new long[n];
        long[] invFact = new long[n];
        fact[0] = 1;
        for (int i = 1; i < n; i++) {
            fact[i] = fact[i - 1] * i % MOD;
        }
        invFact[n - 1] = ModPow(fact[n - 1], MOD - 2);
        for (int i = n - 2; i >= 0; i--) {
            invFact[i] = invFact[i + 1] * (i + 1) % MOD;
        }
        return (fact, invFact);
    }

    private long ModPow(long a, long b) {
        long res = 1;
        a %= MOD;
        while (b > 0) {
            if ((b & 1) == 1) {
                res = res * a % MOD;
            }
            a = a * a % MOD;
            b >>= 1;
        }
        return res;
    }
}