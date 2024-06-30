public class Solution {
    class UnionFind 
    {
        private int[] representative;
        private int[] componentSize;
        public int Components { get; private set; }

        public UnionFind(int n) 
        {
            representative = new int[n + 1];
            componentSize = new int[n + 1];
            Components = n;

            for (int i = 0; i <= n; i++) {
                representative[i] = i;
                componentSize[i] = 1;
            }
        }

        public int FindRepresentative(int x) 
        {
            if (representative[x] == x)
                return x;

            representative[x] = FindRepresentative(representative[x]);
            return representative[x];
        }

        public int PerformUnion(int x, int y)
        {
            x = FindRepresentative(x);
            y = FindRepresentative(y);

            if (x == y) {
                return 0;
            }

            if (componentSize[x] > componentSize[y]) {
                componentSize[x] += componentSize[y];
                representative[y] = x;
            } else {
                componentSize[y] += componentSize[x];
                representative[x] = y;
            }

            Components--;
            return 1;
        }

        public bool IsConnected()
        {
            return Components == 1;
        }
    }
    
    public int MaxNumEdgesToRemove(int n, int[][] edges) {
        // Main function logic
        UnionFind alice = new UnionFind(n);
        UnionFind bob = new UnionFind(n);

        int edgesRequired = 0;

        foreach (var edge in edges) 
        {
            if (edge[0] == 3) 
                edgesRequired += (alice.PerformUnion(edge[1], edge[2]) | bob.PerformUnion(edge[1], edge[2]));
        }

        foreach (var edge in edges) 
        {
            if (edge[0] == 2)
                edgesRequired += bob.PerformUnion(edge[1], edge[2]);
            else if (edge[0] == 1) 
                edgesRequired += alice.PerformUnion(edge[1], edge[2]);
        }

        if (alice.IsConnected() && bob.IsConnected())
            return edges.Length - edgesRequired;

         return -1;
    }
}
