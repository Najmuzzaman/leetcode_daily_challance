public class Solution {
   public long GetDescentPeriods(int[] prices) =>
    prices
        .Append(int.MaxValue)
        .Aggregate(
            (Result: 0L, RunLength: 0L, Previous: int.MaxValue),
            (a, p) =>
                p == a.Previous - 1
                    ? (a.Result, a.RunLength + 1, p)
                    : (a.Result + a.RunLength * (a.RunLength + 1) / 2, 1L, p),
            a => a.Result);
}