public class Solution {
    public int MinimumOperations(int[] nums) {
        List<int> n=nums.ToList();
        int ans=0;
        while(n.Count()>n.Distinct().Count())
        {
            n=n.Skip(3).ToList();
            ans++;
        }
        return ans;
    }
}