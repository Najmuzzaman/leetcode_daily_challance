public class Solution {
   
    public int[] LexicographicallySmallestArray(int[] nums, int limit) {
         int n = nums.Length;
        var vec = new List<(int Value, int Index)>(n);
        for (int i = 0; i < n; i++) 
            vec.Add((nums[i], i));
        int low = 0;
        vec.Sort((a, b) => a.Value.CompareTo(b.Value));
        var newSorting = new int[n];
        newSorting[0] = vec[0].Index;

        for (int i = 1; i < n; i++) 
        {
            if (Math.Abs(vec[i].Value - vec[i - 1].Value) > limit) 
            {
                Array.Sort(newSorting, low, i - low);
                low = i;
            }
            newSorting[i] = vec[i].Index;
        }

        Array.Sort(newSorting, low, n - low);

        var ans = new int[n];

        for (int i = 0; i < n; i++) 
            ans[newSorting[i]] = vec[i].Value;
        return ans;
    }
}