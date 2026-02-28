public class Solution {
    public int ConcatenatedBinary(int n) => Enumerable
    .Range(1, n)
    .Select(Convert.ToUInt64)
    .Aggregate(
        0UL,
        (acc, next) => (
            acc << 64 - BitOperations.LeadingZeroCount(next) | next
        ) % 1_000_000_007UL,
        Convert.ToInt32
    );
}