public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        foreach(int[] edge in edges) {
            int u = edge[0];
            int v = edge[1];
            if (!graph.ContainsKey(u))
                graph[u] = new List<int>();
            if (!graph.ContainsKey(v))
                graph[v] = new List<int>();
            graph[u].Add(v);
            graph[v].Add(u);
        }
        
        HashSet<int> visited = new HashSet<int>();
        Stack<int> stack = new Stack<int>();
        stack.Push(source);

        while (stack.Count > 0) {
            int node = stack.Pop();
            if (node == destination)
                return true;
            
            visited.Add(node);
            foreach (int neighbor in graph.GetValueOrDefault(node, new List<int>())) {
                if (!visited.Contains(neighbor))
                    stack.Push(neighbor);
            }
        }
        
        return false;
    }
}