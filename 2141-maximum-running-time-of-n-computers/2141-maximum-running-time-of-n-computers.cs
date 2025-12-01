public class Solution {
    public long MaxRunTime(int n, int[] batteries) {
       long right = 0, left = 0;
        foreach (int b in batteries)
            right += b;
        right /= n;
        while (left < right) 
        {
            long mid = (left + right + 1) / 2;

            if (check(n, batteries, mid))
                left = mid;
            else
                right = mid - 1;
        }
        return left;
    }

    public bool check(int n, int[] batteries, long T) 
    {
        long total = 0;
        foreach (int b in batteries) 
        {
            total += Math.Min(b, T);
            if (total >= (long) n * T)
                return true;
        }
        return total >= (long) n * T;
    }
}