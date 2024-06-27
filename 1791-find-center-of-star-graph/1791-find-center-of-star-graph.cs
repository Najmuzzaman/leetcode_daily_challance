public class Solution {
    public int FindCenter(int[][] edges) {
        int n = edges.Length + 1;
        int[] dgr = new int[n + 1];

        foreach (int[] edge in edges) 
        {
            dgr[edge[0]]++;
            dgr[edge[1]]++;
        }

        for (int i = 1; i <= n; i++) 
        {
            if (dgr[i] == n - 1) 
                return i;
        }

        return -1;
    }
}