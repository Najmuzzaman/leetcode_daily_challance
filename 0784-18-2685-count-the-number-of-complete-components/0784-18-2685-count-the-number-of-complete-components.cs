public class Solution {
    List<int> componentNodes;
    public int CountCompleteComponents(int n, int[][] edges) {
        componentNodes = new List<int>();
        List<List<int>> adjList = new List<List<int>>(n);
        bool[] visited = new bool[n];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            adjList.Add(new List<int>());
        }
        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                componentNodes = new List<int>();
                DFS(i, visited, adjList);

                int componentCount = componentNodes.Count;
                bool flag = false;
                foreach (int node in componentNodes)
                {
                    if (adjList[node].Count != componentCount - 1)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    count++;
            }
        }

        return count;
    }
    private void DFS(int node, bool[] visited, List<List<int>> adjList)
    {
        componentNodes.Add(node);
        visited[node] = true;

        foreach (int neighbor in adjList[node])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, visited, adjList);
            }
        }
    }
}