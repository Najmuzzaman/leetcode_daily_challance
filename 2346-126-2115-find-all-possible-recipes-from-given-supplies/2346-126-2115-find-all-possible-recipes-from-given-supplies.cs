public class Solution {
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies) {
        HashSet<string> left=new (recipes);
        HashSet<string> ret = [];
        HashSet<string> sup = new (supplies);
        bool changed=true;
        int len = recipes.Length;
        HashSet<int> done=[];;
        while(changed==true)
        {
            changed=false;
            for(int i=0;i<len;i++)
            {
                if(done.Contains(i)) continue;
                if(ingredients[i].All(sup.Contains))
                {
                    sup.Add(recipes[i]);
                    ret.Add(recipes[i]);
                    changed=true;
                    done.Add(i);
                }
            }
        }
        return ret.ToList();
    }
}