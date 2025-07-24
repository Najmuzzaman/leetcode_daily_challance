public class Solution {
    //najmuzzaman
    private List<int>[] tree;
    private int[] subtreeXor;
    private int[] parent;
    private int[] values;

    public int MinimumScore(int[] nums, int[][] edges) 
    {
        int n = nums.Length;
        int e = edges.Length;
        values = nums;
        tree = new List<int>[n];

        for (int i = 0; i < n; i++)
            tree[i] = new List<int>();

        for (int i = 0; i < e; i++)
        {
            tree[edges[i][0]].Add(edges[i][1]);
            tree[edges[i][1]].Add(edges[i][0]);
        }

        subtreeXor = new int[n];
        parent = new int[n];

        dfs(0, -1);

        int res = int.MaxValue;

        for (int i = 0; i < e; i++)
        {
            for (int j = i + 1; j < e; j++)
            {
                var (a, b) = (edges[i][0], edges[i][1]);
                var (c, d) = (edges[j][0], edges[j][1]);

                if (parent[a] == b)
                    (a, b) = (b, a);
                
                if (parent[c] == d)
                    (c, d) = (d, c);

                if (IsDescendant(b, d))
                {
                    int x = subtreeXor[d];
                    int y = subtreeXor[b] ^ subtreeXor[d];
                    int z = subtreeXor[0] ^ subtreeXor[b];

                    res = Math.Min(res, MaxMinusMin(x, y, z));
                }
                else if (IsDescendant(d, b))
                {
                    int x = subtreeXor[b];
                    int y = subtreeXor[d] ^ subtreeXor[b];
                    int z = subtreeXor[0] ^ subtreeXor[d];

                    res = Math.Min(res, MaxMinusMin(x, y, z));
                }
                else
                {
                    int x = subtreeXor[b];
                    int y = subtreeXor[d];
                    int z = subtreeXor[0] ^ x ^ y;
                    
                    res = Math.Min(res, MaxMinusMin(x, y, z));
                }
            }
        }

        return res;
    }

    void dfs(int node, int par)
    {
        subtreeXor[node] = values[node];
        parent[node] = par;

        for (int i = 0; i < tree[node].Count; i++)
        {
            if (tree[node][i] == par)
                continue;

            dfs(tree[node][i], node);

            subtreeXor[node] ^= subtreeXor[tree[node][i]];
        }
    }

    bool IsDescendant(int anc, int desc)
    {
        while (desc != -1)
        {
            if (desc == anc)
                return true;

            desc = parent[desc];
        }

        return false;
    }

    int MaxMinusMin(int a, int b, int c)
    {
        int max = Math.Max(a, Math.Max(b, c));
        int min = Math.Min(a, Math.Min(b, c));

        return max - min;
    }
}