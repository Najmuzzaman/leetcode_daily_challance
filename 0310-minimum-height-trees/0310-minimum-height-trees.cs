public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
       if (n == 1) {
            return new List<int> { 0 }; // Only one node, return the root
        }
        
        Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
        List<int> d = new List<int>(new int[n]);
        
        foreach (var e in edges) {
            int u = e[0];
            int v = e[1];
            if (!g.ContainsKey(u)) {
                g[u] = new List<int>();
            }
            if (!g.ContainsKey(v)) {
                g[v] = new List<int>();
            }
            g[u].Add(v);
            g[v].Add(u);
            d[u]++;
            d[v]++;
        }
        
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < n; i++) {
            if (d[i] == 1) {
                q.Enqueue(i);
            }
        }
        
        int r = n;
        while (r > 2) {
            int size = q.Count;
            r -= size;
            
            for (int i = 0; i < size; i++) {
                int l = q.Dequeue();
                foreach (int ne in g[l]) {
                    d[ne]--;
                    if (d[ne] == 1) {
                        q.Enqueue(ne);
                    }
                }
            }
        }
        
        IList<int> result = new List<int>();
        while (q.Count > 0) {
            result.Add(q.Dequeue());
        }
        
        return result;
    }
}