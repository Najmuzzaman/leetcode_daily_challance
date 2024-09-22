public class Solution {
    public int FindKthNumber(int n, int k) {
        int curr = 1;
        k--;  // Decrement k because we're starting at the first number (1)

        while (k > 0) {
            int steps = CalculateSteps(n, curr, curr + 1);

            if (steps <= k) {
                // Move to the next prefix
                curr++;
                k -= steps;
            } else {
                // Go deeper in the current prefix
                curr *= 10;
                k--;
            }
        }

        return curr;
    }
    private int CalculateSteps(int n, long prefix, long nextPrefix) {
        int steps = 0;

        while (prefix <= n) {
            steps += (int)Math.Min(n + 1, nextPrefix) - (int)prefix;
            prefix *= 10;
            nextPrefix *= 10;
        }

        return steps;
    }
}