public class Solution {
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var graph = new List<List<int>>(numCourses);
        for (int i = 0; i < numCourses; i++)
            graph.Add(new List<int>());
        
        var indegree = new int[numCourses];

        // Build the graph and indegree array
        foreach (var prerequisite in prerequisites)
        {
            graph[prerequisite[0]].Add(prerequisite[1]);
            indegree[prerequisite[1]]++;
        }

        var queue = new Queue<int>();
        var pre = new HashSet<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
            pre[i] = new HashSet<int>();

        // Enqueue courses with no prerequisites
        for (int u = 0; u < numCourses; u++)
            if (indegree[u] == 0)
                queue.Enqueue(u);

        // Process courses in topological order
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();

            foreach (int v in graph[u])
            {
                pre[v].Add(u);
                foreach (var item in pre[u])
                    pre[v].Add(item);

                indegree[v]--;
                if (indegree[v] == 0)
                    queue.Enqueue(v);
            }
        }

        // Process queries
        var ans = new List<bool>(queries.Length);
        foreach (var query in queries)
        {
            int u = query[0], v = query[1];
            ans.Add(pre[v].Contains(u));
        }

        return ans;
    }
}