public class Solution {
    public int MaxSumAfterPartitioning(int[] arr, int k) {
        int n = arr.Length;
        int K = k + 1;

        int[] dp = new int[k + 1];

        for (int start = n - 1; start >= 0; start--) {
            int Ma = 0;
            int end = Math.Min(n, start + k);

            for (int i = start; i < end; i++) {
                Ma = Math.Max(Ma, arr[i]);
                dp[start % K] = Math.Max(dp[start % K], dp[(i + 1) % K] + Ma * (i - start + 1));
            }
        }
        return dp[0];
    }
}