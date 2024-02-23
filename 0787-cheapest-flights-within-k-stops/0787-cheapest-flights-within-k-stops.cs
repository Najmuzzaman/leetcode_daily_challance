public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
       Dictionary<int, List<int[]>> adj = new Dictionary<int, List<int[]>>();
        int[] visited = new int[n];
        Array.Fill(visited, int.MaxValue);
        visited[src] = 0;
        
        foreach (int[] flight in flights) {
            if (!adj.ContainsKey(flight[0])) {
                adj[flight[0]] = new List<int[]>();
            }
            adj[flight[0]].Add(new int[]{flight[1], flight[2]});
        }
        
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[]{src, 0});
        k++;
        
        while (queue.Count > 0 && k-- > 0) {
            int size = queue.Count;
            while (size-- > 0) {
                int[] curr = queue.Dequeue();
                int currNode = curr[0];
                int currPrice = curr[1];
                if (adj.ContainsKey(currNode)) {
                    foreach (int[] neighbor in adj[currNode]) {
                        int newPrice = currPrice + neighbor[1];
                        if (newPrice < visited[neighbor[0]]) {
                            visited[neighbor[0]] = newPrice;
                            queue.Enqueue(new int[]{neighbor[0], newPrice});
                        }
                    }
                }
            }
        }
        
        return visited[dst] == int.MaxValue ? -1 : visited[dst];
    }
}