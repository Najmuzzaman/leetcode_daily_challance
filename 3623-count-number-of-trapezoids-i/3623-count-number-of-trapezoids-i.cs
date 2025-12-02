public class Solution {
    private static int Modulo = Enumerable.Repeat(10, 9).Aggregate(1, (a, b) => a * b) + 7;
    public int CountTrapezoids(int[][] points) => (int)
        points
            .GroupBy(p => p[1])
            .Select(g => g.Count())
            .Where(cnt => cnt > 1)
            .Select(cnt => (long)cnt * (cnt - 1) / 2)
            .Aggregate(
                (Result: 0L, Prefix: 0L),
                (acc, val) => (
                    (acc.Result + val * acc.Prefix) % Modulo,
                    (acc.Prefix + val) % Modulo
                )
            ).Result;
}