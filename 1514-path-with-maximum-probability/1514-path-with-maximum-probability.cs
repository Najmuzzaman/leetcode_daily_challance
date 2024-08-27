public class Solution {
   
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node)
    {
        double[] dist = new double[n];
        dist[start_node] = 1.0;

        for (int i = 0; i < n - 1; i++) 
        {
            bool updated = false;
            for (int j = 0; j < edges.Length; j++) 
            {
                int u = edges[j][0];
                int v = edges[j][1];

                if (dist[u] * succProb[j] > dist[v])
                {
                    dist[v] = dist[u] * succProb[j];
                    updated = true;
                }
                if (dist[v] * succProb[j] > dist[u])
                {
                    dist[u] = dist[v] * succProb[j];
                    updated = true;
                }
            }
            if (!updated)
                break;
        }

        return dist[end_node];
    }
}

