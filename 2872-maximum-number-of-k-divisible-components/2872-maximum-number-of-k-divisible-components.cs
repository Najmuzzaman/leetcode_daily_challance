public class Solution {
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k) {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) 
            graph[i] = new List<int>();
        
        foreach (int[] edge in edges) 
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        int count = 0;
        DFS(graph, 0, -1, values); 


        int DFS(List<int>[] graph, int node, int parent, int[] values) 
        {
            int sum=0;
            foreach (int neighbor in graph[node]) {
                if (neighbor != parent) {
                    sum += DFS(graph, neighbor, node, values);
                    sum %=k;
                }
            }
            
            sum+=values[node];
            sum %=k;
            
            if(sum==0) count++;
            return sum;            
        }
       
        return count;
    }
}