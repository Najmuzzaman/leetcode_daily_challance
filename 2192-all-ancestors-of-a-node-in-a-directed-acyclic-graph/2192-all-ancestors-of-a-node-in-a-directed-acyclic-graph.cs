public class Solution {
    public IList<IList<int>> GetAncestors(int n, int[][] edges) 
    {
        IList<IList<int>> ans = new List<IList<int>>();
        List<List<int>> dc = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            ans.Add(new List<int>());
            dc.Add(new List<int>());
        }
        foreach (int[] e in edges)
            dc[e[0]].Add(e[1]);
        for (int i = 0; i < n; i++)
            Dfs(i, i, ans, dc);
        return ans;
    }
    private void Dfs(int x, int curr, IList<IList<int>> ans, List<List<int>> dc)
    {
        foreach (int ch in dc[curr])
        {
            if (ans[ch].Count == 0 || ans[ch][ans[ch].Count - 1] != x)
            {
                ans[ch].Add(x);
                Dfs(x, ch, ans, dc);
            }
        }
    }
}