public class Solution {
    public int MaxSubarrayLength(int[] nums, int k) {
        int n = nums.Length;
        Dictionary<int, int> fre = new Dictionary<int, int>();
        int l = 0, r = 0;
        int ml = 1;
        
        while (l < n && r < n) {
            if (!fre.ContainsKey(nums[r]))
                fre[nums[r]] = 0;
            fre[nums[r]]++;
            
            while (fre[nums[r]] > k) {
                fre[nums[l]]--;
                l++;
            }
            
            ml = Math.Max(ml, r - l + 1);
            r++;
        }
        
        return ml;
    }
}