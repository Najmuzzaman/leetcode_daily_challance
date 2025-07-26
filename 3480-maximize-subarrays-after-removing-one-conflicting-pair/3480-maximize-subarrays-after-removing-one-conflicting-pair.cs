public class Solution {
    public long MaxSubarrays(int n, int[][] conflictingPairs) {
        var right = Enumerable.Range(0, n + 1).Select(x => new List<int>()).ToArray();

        foreach (int[] x in conflictingPairs)
            right[Math.Max(x[0], x[1])].Add(Math.Min(x[0], x[1]));

        long ans = 0, add = 0;
        int m = 0, sm = 0;
        long[] imp = new long[n + 1];

        for (int r = 1; r <= n; r++)
        {
            foreach (int l in right[r])
                if (l > m)
                {
                    sm = m;
                    m = l;
                }
                else sm = Math.Max(sm, l);

            ans += r - m;
            imp[m] += m - sm;
            add = Math.Max(add, imp[m]);
        }
        return ans + add;
    }
}