public class Solution {
    public double New21Game(int n, int k, int maxPts) {
        if (k == 0 || k + maxPts <= n)
            return 1.0;
       
        double[] ar = new double[n + 1];
        double sum = 1.0;
        double ans = 0.0;
        ar[0] = 1;
        for (int i = 1; i < n+1; i++)
        {
            ar[i] = sum / maxPts;
            if (i < k)
                sum += ar[i];
            else
                ans += ar[i];
            if (i - maxPts >= 0)
                sum = sum - ar[i - maxPts];
        }
        return ans;
    }
}