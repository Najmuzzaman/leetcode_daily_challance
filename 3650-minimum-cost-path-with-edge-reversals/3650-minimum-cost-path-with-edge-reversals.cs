public class Solution {
    public int MinCost(int n, int[][] edges) {
        List<(int Vertex, int Weight)>[] graph = BuildGraph(n, edges);        
        var path = new PriorityQueue<int, int>();
        path.Enqueue(0, 0);        
        var visited = new HashSet<int>();
        while (path.TryDequeue(out int vertex, out int weight))
        {
            if (vertex == n - 1)
                return weight;

            if (!visited.Add(vertex))
                continue;            

            foreach ((int Vertex, int Weight) nextVertex in graph[vertex])            
                path.Enqueue(nextVertex.Vertex, weight + nextVertex.Weight);            
        }
        return -1;
    }

    private static List<(int Vertex, int Weight)>[] BuildGraph(int n, int[][] edges)
    {
        var graph = new List<(int Vertex, int Weight)>[n];
        for (int v = 0; v < n; v++)        
            graph[v] = new();
        

        foreach (int[] edge in edges)
        {
            int parent = edge[0];
            int child = edge[1];
            int weight = edge[2];

            graph[parent].Add((child, weight));
            graph[child].Add((parent, weight * 2));
        }
        return graph;
    }
}