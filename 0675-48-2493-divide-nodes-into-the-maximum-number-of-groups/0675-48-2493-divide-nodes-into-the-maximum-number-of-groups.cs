public class Solution {
    public int MagnificentSets(int n, int[][] edges) {
        UnionFind uf = new UnionFind(n + 1);
        List<int>[] graph = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) graph[i] = new List<int>();
        
        foreach (var edge in edges) { // 1. Build graph, connect nodes
            int a = edge[0], b = edge[1];
            graph[a].Add(b);
            graph[b].Add(a);
            uf.Union(a, b);
        }

        Dictionary<int, List<int>> groups = new Dictionary<int, List<int>>();
        for (int i = 1; i <= n; i++) { // 2. Find groups of connected nodes
            int parent = uf.Find(i);
            if (!groups.ContainsKey(parent)) groups[parent] = new List<int>();
            groups[parent].Add(i);
        }

        int totalGroups = 0;
        foreach (var entry in groups) { // 3. Find the maximum groups to divide for each connected group
            List<int> group = entry.Value;
            int maxGroups = 0;
            foreach (int node in group) {
                int numGroups = BFS(graph, node);
                if (numGroups == -1) return -1;
                maxGroups = Math.Max(maxGroups, numGroups);
            }
            totalGroups += maxGroups;
        }
        return totalGroups;
    }

    private int BFS(List<int>[] graph, int startNode) {
        Queue<int> queue = new Queue<int>();
        int n = graph.Length;
        int[] levels = new int[n];
        Array.Fill(levels, -1);
        int level = 0;
        queue.Enqueue(startNode);
        levels[startNode] = 0;
        
        while (queue.Count > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                int node = queue.Dequeue();
                foreach (int nei in graph[node]) {
                    if (levels[nei] == -1) {
                        levels[nei] = level + 1;
                        queue.Enqueue(nei);
                    } else if (levels[nei] == level) { // found an odd-length cycle, we can't divide into groups
                        return -1;
                    }
                }
            }
            level++;
        }
        return level;
    }
}


public class UnionFind {
    private int[] root;
    private int[] rank;
    
    public UnionFind(int size) {
        root = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++) {
            root[i] = i;
            rank[i] = 1;
        }
    }
    
    public int Find(int x) {
        if (root[x] == x) return x;
        return root[x] = Find(root[x]);
    }
    
    public void Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY) {
            if (rank[rootX] > rank[rootY]) {
                root[rootY] = rootX;
            } else if (rank[rootX] < rank[rootY]) {
                root[rootX] = rootY;
            } else {
                root[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }
    
    public bool Connected(int x, int y) {
        return Find(x) == Find(y);
    }
}
