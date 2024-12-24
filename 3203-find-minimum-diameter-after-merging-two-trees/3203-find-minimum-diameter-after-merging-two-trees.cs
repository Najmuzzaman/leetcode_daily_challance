public class Solution {
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2) {
         // Calculate the number of nodes for each tree (number of edges + 1)
        int n = edges1.Length + 1;
        int m = edges2.Length + 1;

        // Build adjacency lists for both trees
        var adjList1 = BuildAdjList(n, edges1);
        var adjList2 = BuildAdjList(m, edges2);

        // Calculate the diameter of both trees
        int diameter1 = FindDiameter(n, adjList1);
        int diameter2 = FindDiameter(m, adjList2);

        // Calculate the longest path that spans across both trees
        int combinedDiameter =
            (int)Math.Ceiling(diameter1 / 2.0) +
            (int)Math.Ceiling(diameter2 / 2.0) +
            1;

        // Return the maximum of the three possibilities
        return Math.Max(Math.Max(diameter1, diameter2), combinedDiameter);
    }
    
    private List<List<int>> BuildAdjList(int size, int[][] edges)
    {
        var adjList = new List<List<int>>();
        for (int i = 0; i < size; i++)
        {
            adjList.Add(new List<int>());
        }
        foreach (var edge in edges)
        {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        return adjList;
    }

    // Function to find the diameter of a tree
    private int FindDiameter(int n, List<List<int>> adjList)
    {
        var leavesQueue = new Queue<int>();
        var degrees = new int[n];

        // Initialize the degree of each node and add leaves (nodes with degree 1) to the queue
        for (int node = 0; node < n; node++)
        {
            degrees[node] = adjList[node].Count;
            if (degrees[node] == 1)
            {
                leavesQueue.Enqueue(node);
            }
        }

        int remainingNodes = n;
        int leavesLayersRemoved = 0;

        // Process the leaves until there are 2 or fewer nodes remaining
        while (remainingNodes > 2)
        {
            int size = leavesQueue.Count;
            remainingNodes -= size;
            leavesLayersRemoved++;

            // Remove the leaves from the queue and update the degrees of their neighbors
            for (int i = 0; i < size; i++)
            {
                int currentNode = leavesQueue.Dequeue();

                // Process the neighbors of the current leaf
                foreach (var neighbor in adjList[currentNode])
                {
                    degrees[neighbor]--;
                    if (degrees[neighbor] == 1)
                    {
                        leavesQueue.Enqueue(neighbor);
                    }
                }
            }
        }

        // If exactly two nodes remain, return the diameter as twice the number of layers of leaves removed + 1
        if (remainingNodes == 2) return 2 * leavesLayersRemoved + 1;

        return 2 * leavesLayersRemoved;
    }

}