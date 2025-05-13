public class Solution {
     private const int MOD = 1_000_000_007;

    public int LengthAfterTransformations(string s, int t) {
        long[] letterCounts = new long[26];

        // Count initial frequency of each character
        foreach (char ch in s) {
            letterCounts[ch - 'a']++;
        }

        for (int step = 0; step < t; step++) {
            long[] updatedCounts = new long[26];

            // Shift frequencies to the next character
            for (int i = 0; i < 25; i++) {
                updatedCounts[i + 1] = (updatedCounts[i + 1] + letterCounts[i]) % MOD;
            }

            // Special transformation for 'z'
            long zCount = letterCounts[25];
            updatedCounts[0] = (updatedCounts[0] + zCount) % MOD;
            updatedCounts[1] = (updatedCounts[1] + zCount) % MOD;

            letterCounts = updatedCounts;
        }

        long resultLength = 0;
        foreach (long count in letterCounts) {
            resultLength = (resultLength + count) % MOD;
        }

        return (int)resultLength;
    }
}