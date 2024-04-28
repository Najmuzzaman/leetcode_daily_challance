public class Solution {
    
    public int[] SumOfDistancesInTree(int n, int[][] edges) {
      Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) {
            g[i] = new List<int>();
        }
        foreach (var e in edges) {
            int u = e[0];
            int v = e[1];
            g[u].Add(v);
            g[v].Add(u);
        }

        int[] count = new int[n];
        int[] ans = new int[n];
        for (int i = 0; i < n; i++) {
            count[i] = 1;
        }

        dfs(0, -1);

        void dfs(int node, int p) {
            foreach (var c in g[node]) {
                if (c != p) {
                    dfs(c, node);
                    count[node] += count[c];
                    ans[node] += ans[c] + count[c];
                }
            }
        }

        dfs2(0, -1);

        void dfs2(int node, int p) {
            foreach (var c in g[node]) {
                if (c != p) {
                    ans[c] = ans[node] - count[c] + (n - count[c]);
                    dfs2(c, node);
                }
            }
        }

        return ans;
    }
}