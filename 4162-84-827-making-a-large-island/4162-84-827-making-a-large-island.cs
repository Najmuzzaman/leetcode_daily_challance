public class Solution {
    public int LargestIsland(int[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        int[] parent = new int[m * n];
        int[] size = new int[m * n];
        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };
        
        for (int i = 0; i < m * n; i++) {
            parent[i] = i;
            size[i] = 1;
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) {
                    for (int k = 0; k < 4; k++) {
                        int ni = i + dx[k], nj = j + dy[k];
                        if (IsValid(ni, nj, n, m) && grid[ni][nj] == 1) {
                            Union(i * m + j, ni * m + nj, parent, size);
                        }
                    }
                }
            }
        }
        int maxIsland = 0;
        for (int i = 0; i < n * m; i++) {
            if (Find(i, parent) == i) {
                maxIsland = Math.Max(maxIsland, size[i]);
            }
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 0) {
                    int newSize = 1;
                    HashSet<int> uniqueParents = new HashSet<int>();
                    for (int k = 0; k < 4; k++) {
                        int ni = i + dx[k], nj = j + dy[k];
                        if (IsValid(ni, nj, n, m) && grid[ni][nj] == 1) {
                            int root = Find(ni * m + nj, parent);
                            if (!uniqueParents.Contains(root)) {
                                newSize += size[root];
                                uniqueParents.Add(root);
                            }
                        }
                    }
                    maxIsland = Math.Max(maxIsland, newSize);
                }
            }
        }
        
        return maxIsland;
    }

       private int Find(int value, int[] parent) {
        if (value == parent[value]) return value;
        return parent[value] = Find(parent[value], parent);
    }

    private void Union(int value1, int value2, int[] parent, int[] size) {
        int parent1 = Find(value1, parent);
        int parent2 = Find(value2, parent);
        if (parent1 != parent2) {
            if (size[parent1] < size[parent2]) {
                (parent1, parent2) = (parent2, parent1);
            }
            parent[parent2] = parent1;
            size[parent1] += size[parent2];
        }
    }

    private bool IsValid(int i, int j, int n, int m) {
        return i >= 0 && i < n && j >= 0 && j < m;
    }
}