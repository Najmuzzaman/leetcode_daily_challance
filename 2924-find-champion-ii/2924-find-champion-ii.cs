public class Solution {
   public void dfs(int v,bool[] visit,List<int>[] graph)
    {
        visit[v]=true;
        for(int i=0;i<graph[v].Count;i++)
        {
            if (!visit[graph[v][i]])
                dfs(graph[v][i], visit, graph);
        }
    }

    public int FindChampion(int n, int[][] edges) {
        if(n==1) return 0;        
        List<int>[] graph=new List<int>[n];
        for (int i = 0; i < n;i++ )
            graph[i] = new List<int>();

        for (int i = 0; i < edges.Length; i++)
        {

            graph[edges[i][0]].Add(edges[i][1]);
        }
        bool flag=false;
        int ans=-1;
        for(int i=0;i<n;i++)
        {
            bool[] visit=new bool[n];
            bool checkvisit=true;
            dfs(i, visit,graph);
            for(int j=0;j<n;j++)
            {
                if(!visit[j]) 
                {
                    checkvisit=false;
                    break;
                }
            }
            if(checkvisit)
            {
                if(flag) return -1;
                flag=true;
                ans=i;
            }
        }
        return ans;
    }
}