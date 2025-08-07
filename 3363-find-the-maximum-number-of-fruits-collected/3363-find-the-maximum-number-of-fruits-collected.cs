public class Solution {
    public int MaxCollectedFruits(int[][] fruits) {
        int total = 0;
        int n = fruits.Length;
        int n1 = n - 1;

        for (int i = 0; i < n; i++) 
            total += fruits[i][i];

        int[] sumsP = new int[0];
        for (int i = 0; i < n1; i++) {           
            int[] sums = GetArray(i, n, sumsP);
                
            for (int j = 0; j < sums.Length; j++) 
                sums[j] = fruits[i][n1 - j] + PreviousMax(j, sumsP);

            sumsP = sums;
        }

        total += sumsP[0];

        sumsP = new int[0];
        for (int i = 0; i < n1; i++) 
        {           
            int[] sums = GetArray(i, n, sumsP);
                
            for (int j = 0; j < sums.Length; j++)
                sums[j] = fruits[n1 - j][i] + PreviousMax(j, sumsP);

            sumsP = sums;
        }
        total += sumsP[0];

        return total;
    }

    private int[] GetArray(int i, int n, int[] sumsP) 
    {
        int nh = n / 2;
        int nm = -1;
        if (n % 2 == 1) nm = nh;

        int[] sums;
        if (i < nh)
            sums = new int[sumsP.Length + 1];
        else if (i == nm)
            sums = new int[sumsP.Length];
        else
            sums = new int[sumsP.Length - 1];

        return sums;
    }

    private int PreviousMax(int j, int[] sumsP) {
        List<int> p = new();
        
        if (j > 0)
            p.Add(sumsP[j - 1]);
    

        if (j < sumsP.Length)
            p.Add(sumsP[j]);

        if (j + 1 < sumsP.Length)
            p.Add(sumsP[j + 1]);

        if (p.Any())
            return p.Max();

        return 0;
    }
}