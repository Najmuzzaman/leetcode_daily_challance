public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
         int[] a = new int[100009];
         int n = nums.Length;
         List<int> ans = new List<int>();
         for (int i = 0; i < n; i++)
         {
             a[nums[i]]++;
             if (a[nums[i]] == 2)
                 ans.Add(nums[i]);
         }
         return ans;        
    }
}