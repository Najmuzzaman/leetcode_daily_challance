public class Solution {
    public int[] ProductQueries(int n, int[][] queries) {
        List<int> powers = new();
        int cur = n, digs = 0, qLen = queries.Length, mod = 1000000007;
        while(cur > 0)
        {
            int rem = cur%2;
            cur /= 2;
            if(rem == 1)
                powers.Add((int)Math.Pow(2, digs));

            digs++;
        }

        int[] res = new int[qLen];
        int[,] dp = new int[digs, digs];
        int pLen = powers.Count;

        for(int i = 0; i < pLen; i++)
        {
            dp[i,i] = powers[i];
            long curL = powers[i];
            for(int j = i+1; j < pLen; j++)
            {
                curL = (curL*powers[j])%mod;
                dp[i,j] = (int)curL;
            }
        }

        for(int i = 0; i < qLen; i++)
        {
            int start = queries[i][0], end = queries[i][1];
            
           // Console.WriteLine($"{i}th, start is {start}, end is {end}, digs is {digs}");
            res[i] = dp[start, end];
        }

        return res;
    }
}