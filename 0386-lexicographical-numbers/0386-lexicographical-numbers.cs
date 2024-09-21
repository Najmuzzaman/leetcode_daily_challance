public class Solution {
    public IList<int> LexicalOrder(int n) {
        IList<int> Ans=new List<int>();
        for(int i=1;i<=n;i++)
            Ans.Add(i);
        Ans= Ans.OrderBy(x => x.ToString()).ToList();
        return Ans; 
    }
}