public class Solution {
    public long MostPoints(int[][] questions) 
    {
        int n = questions.Length;
        long[] v=new long[n];
        v[n-1] = questions[n-1][0];
        for(int i = n-2; i >= 0; i--)
        {
            long p = questions[i][0];
            long b = questions[i][1];
            long next = Math.Min(i+b+1, n);
            long x = p + (next < n? v[next] : 0);
            long y = v[i+1];
            v[i] = Math.Max(x, y); 
        }
        return v[0];
    }
}