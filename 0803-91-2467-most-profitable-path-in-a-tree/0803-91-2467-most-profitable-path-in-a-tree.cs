public class Solution {
    private List<int>[] g;
    private int[] amount;
    private int[] ts;
    private int ans = int.MinValue;
    public int MostProfitablePath(int[][] edges, int bob, int[] amount) {
        int n = edges.Length + 1;
        g = new List<int>[n];
        ts = new int[n];
        this.amount = amount;
        
        for (int i = 0; i < n; i++) {
            g[i] = new List<int>();
            ts[i] = n;
        }
        
        foreach (var e in edges) {
            int a = e[0], b = e[1];
            g[a].Add(b);
            g[b].Add(a);
        }
        
        Dfs1(bob, -1, 0);
        ts[bob] = 0;
        Dfs2(0, -1, 0, 0);
        
        return ans;
    }
    private bool Dfs1(int i, int fa, int t) {
        if (i == 0) {
            ts[i] = Math.Min(ts[i], t);
            return true;
        }
        
        foreach (int j in g[i]) {
            if (j != fa && Dfs1(j, i, t + 1)) {
                ts[j] = Math.Min(ts[j], t + 1);
                return true;
            }
        }
        return false;
    }

    private void Dfs2(int i, int fa, int t, int v) {
        if (t == ts[i]) {
            v += amount[i] >> 1;
        } else if (t < ts[i]) {
            v += amount[i];
        }
        
        if (g[i].Count == 1 && g[i][0] == fa) {
            ans = Math.Max(ans, v);
            return;
        }
        
        foreach (int j in g[i]) {
            if (j != fa) {
                Dfs2(j, i, t + 1, v);
            }
        }
    }
}