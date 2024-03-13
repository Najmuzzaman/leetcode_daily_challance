public class Solution {
    public int PivotInteger(int n) {
        double x = Math.Sqrt(n * (n + 1) / 2);
    
        if (x % 1 != 0)
            return -1;
        else
            return (int)Math.Floor(x);
    }
}