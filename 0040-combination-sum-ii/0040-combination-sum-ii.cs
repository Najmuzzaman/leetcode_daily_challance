public class Solution {
    static public void dfs(int target, int v, int loc, int[] candidates, int n, IList<IList<int>> list, IList<int> l)
    {
        if (v == target)
        {
            list.Add(new List<int>(l)); // Create a new list to avoid reference issues
            return;
        }
        if(v>target) return;
        if(loc==n) return;
       
        l.Add(candidates[loc]);
        dfs(target, v + candidates[loc], loc + 1, candidates, n, list, l);
        l.RemoveAt(l.Count - 1); // Backtrack: remove the last element
        while( (loc+1) <n && candidates[loc] == candidates[loc+1])
        {
            loc = loc + 1; 
        }
        dfs(target, v, loc + 1, candidates, n, list, l);        
    }

    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        int n = candidates.Length;
        IList<IList<int>> list = new List<IList<int>>();
        IList<int> l = new List<int>();
        dfs(target, 0, 0, candidates, n, list, l);
        return list;
    }
}