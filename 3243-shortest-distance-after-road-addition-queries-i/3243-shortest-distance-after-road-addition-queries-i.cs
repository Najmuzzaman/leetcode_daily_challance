public class Solution {
     public int CalculateShortestPath(List<List<int>> graph, int totalNodes)
    {
        int[] shortestDistance = new int[totalNodes];
        shortestDistance[totalNodes - 1] = 0; // Base case: distance to the target node is 0

        // Iterate backward from the second-to-last node to the first node
        for (int current = totalNodes - 2; current >= 0; current--)
        {
            int minSteps = totalNodes;
            // Check all connected neighbors to find the shortest distance
            foreach (int neighbor in graph[current])
            {
                minSteps = Math.Min(minSteps, shortestDistance[neighbor] + 1);
            }
            shortestDistance[current] = minSteps; // Store the shortest distance for the current node
        }
        return shortestDistance[0];
    }
    
    public int[] ShortestDistanceAfterQueries(int n, int[][] updates) {
       
        List<List<int>> graph = new List<List<int>>(n);

        for (int i = 0; i < n; i++)
        {
            graph.Add(new List<int>());
        }

        
        for (int i = 0; i < n - 1; i++)
        {
            graph[i].Add(i + 1);
        }

         int[] results = new int[updates.Length];
        int j=0;
        foreach (int[] update in updates)
        {
            int sourceNode = update[0];
            int targetNode = update[1];
            graph[sourceNode].Add(targetNode);
            
            results[j++]=CalculateShortestPath(graph, n);
        }
        return results;
    }
}