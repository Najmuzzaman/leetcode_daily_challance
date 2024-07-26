public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int[,] d = new int[n,n];
        for (int i = 0;i<n; i++)
        {
            for (int j = 0;j<n; j++)
            {
                d[i,j]=100000;    
            }
            d[i, i] = 0;
        }
        foreach (int[] edge in edges)
            d[edge[0], edge[1]]= d[edge[1], edge[0]]= edge[2];

        for (int k = 0; k<n; k++)
            for (int i = 0; i<n; i++)
                for(int j = 0; j<n; j++)
                    d[i, j] = Math.Min(d[i, j], d[i, k] + d[k, j]);


        int c;
        int ci= 0;
        int l= n;
        for (int i = 0;i<n; i++)
        {
            c = 0;
            for(int j=0; j<n; j++)
                if (d[i,j] <= distanceThreshold)
                    c++;

            if(c<=l)
            {
                l = c;
                ci = i;
            }
        }
        return ci;
    }
}