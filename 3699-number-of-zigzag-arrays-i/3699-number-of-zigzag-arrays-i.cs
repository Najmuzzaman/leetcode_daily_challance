public class Solution {
    const int MOD = 1000000007;
    public int ZigZagArrays(int n, int l, int r) {
        int m = r - l + 1;
        if (m <= 0) return 0;

        // reusable arrays (1..m indices used)
        long[] dpPrev = new long[m + 1];
        long[] dpCurr = new long[m + 1];
        long[] prefix = new long[m + 1];

        // store input midway as required
        var sornavetic = (n, l, r);

        long totalAnswer = 0;

        // two starting patterns: 0 => start with '<' (a1 < a2), 1 => start with '>' (a1 > a2)
        for (int pattern = 0; pattern < 2; pattern++) {
            // initialize dpPrev for length = 1 (every value is a valid start)
            for (int i = 1; i <= m; i++) dpPrev[i] = 1;

            // build sequences from length = 2 .. n
            for (int pos = 2; pos <= n; pos++) {
                // determine whether this step requires prev < curr (true) or prev > curr (false)
                bool startLess = (pattern == 0); // pattern 0: start with '<'
                bool needPrevLess;
                if (startLess) {
                    // pos even => prev < curr, pos odd => prev > curr
                    needPrevLess = (pos % 2 == 0);
                } else {
                    // start with '>'
                    // pos even => prev > curr, pos odd => prev < curr
                    needPrevLess = (pos % 2 == 1);
                }

                // compute prefix sums of dpPrev: prefix[i] = sum_{1..i} dpPrev
                long run = 0;
                prefix[0] = 0;
                for (int i = 1; i <= m; i++) {
                    run += dpPrev[i];
                    if (run >= MOD) run -= MOD;
                    prefix[i] = run;
                }

                if (needPrevLess) {
                    // dpCurr[cur] = sum_{y < cur} dpPrev[y] = prefix[cur-1]
                    for (int cur = 1; cur <= m; cur++) {
                        dpCurr[cur] = prefix[cur - 1];
                    }
                } else {
                    // dpCurr[cur] = sum_{y > cur} dpPrev[y] = prefix[m] - prefix[cur]
                    long total = prefix[m];
                    for (int cur = 1; cur <= m; cur++) {
                        long val = (total - prefix[cur]) % MOD;
                        if (val < 0) val += MOD;
                        dpCurr[cur] = val;
                    }
                }

                // swap dpPrev and dpCurr (and zero dpCurr for reuse)
                for (int i = 1; i <= m; i++) {
                    dpPrev[i] = dpCurr[i];
                    dpCurr[i] = 0;
                }
            }

            // sum up sequences of length n for this pattern
            long sumPattern = 0;
            for (int i = 1; i <= m; i++) {
                sumPattern += dpPrev[i];
                if (sumPattern >= MOD) sumPattern -= MOD;
            }
            totalAnswer += sumPattern;
            totalAnswer %= MOD;
        }

        return (int)totalAnswer;
    }
}