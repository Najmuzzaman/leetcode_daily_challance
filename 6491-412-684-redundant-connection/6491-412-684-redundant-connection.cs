public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        int[] parent = new int[n + 1];
        int[] rank = new int[n + 1];

        for (int i = 1; i <= n; i++) {
            parent[i] = i;
        }

        int Find(int i) {
            if (parent[i] != i) {
                parent[i] = Find(parent[i]);
            }
            return parent[i];
        }

        void Union(int u, int v) {
            int rootU = Find(u);
            int rootV = Find(v);
            
            if (rootU != rootV) {
                if (rank[rootU] > rank[rootV]) {
                    parent[rootV] = rootU;
                } else if (rank[rootU] < rank[rootV]) {
                    parent[rootU] = rootV;
                } else {
                    parent[rootV] = rootU;
                    rank[rootU]++;
                }
            }
        }

        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            if (Find(u) == Find(v)) {
                return edge;
            }
            Union(u, v);
        }
        
        return new int[] {};
    }
}