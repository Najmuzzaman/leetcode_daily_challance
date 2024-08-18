public class Solution {
    
    static long[] Precal(int n)
    {
        long[] number = new long[10000];
        number[1] = 1;
        bool flag = true;
        long currentvalue = 1;
        for (int ii = 2; ii <= n; ii++)
        {
            long m = int.MaxValue;
            for (int i = 1; i < ii; i++)
            {
                long po = 0;
                long a = number[i] * 2;
                if (a > currentvalue)
                    po = a;
                if (po == 0)
                {
                    long b = number[i] * 3;
                    if (b > currentvalue)
                        po = b;
                }
                if (po == 0)
                {
                    long c = number[i] * 5;
                    if (c > currentvalue)
                        po = c;
                }
                if (po != 0)
                {
                    m =Math.Min(po,m);
                }
            }
            number[ii] = m;
            currentvalue = m;
        }
        return number;
    }    
    public int NthUglyNumber(int n) 
    {
        long[] ans=Precal(n);
        return (int)ans[n];
    }
}