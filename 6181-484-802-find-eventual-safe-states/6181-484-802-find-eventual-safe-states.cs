public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        int n = graph.Length;
        int[] color = new int[n]; 

        List<int> safeNodes = new List<int>();

        for (int i = 0; i < n; i++) {
            if (IsSafe(i, graph, color)) {
                safeNodes.Add(i);
            }
        }

        return safeNodes;
    }
    private bool IsSafe(int node, int[][] graph, int[] color) {
        if (color[node] > 0) {
            return color[node] == 2;
        }

        color[node] = 1; 

        foreach (int neighbor in graph[node]) {
            if (!IsSafe(neighbor, graph, color)) {
                return false;
            }
        }

        color[node] = 2; 
        return true;
    }
}