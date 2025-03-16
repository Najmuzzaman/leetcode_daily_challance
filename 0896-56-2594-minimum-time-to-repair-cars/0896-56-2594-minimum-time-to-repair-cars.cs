public class Solution {
    public long RepairCars(int[] ranks, int cars) {
        long l = 1, h = (long) ranks.Min() * cars * cars;
        while (l < h) {
            long m = (l + h) / 2;
            if (CanRepairAll(ranks, cars, m)) {
                h = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }

    private bool CanRepairAll(int[] ranks, int cars, long m) 
    {
        long t = 0;
        foreach(int rank in ranks) 
        {
            t += (long)Math.Sqrt(m / rank);
            if (t >= cars) return true;
        }
        return false;
    }
}