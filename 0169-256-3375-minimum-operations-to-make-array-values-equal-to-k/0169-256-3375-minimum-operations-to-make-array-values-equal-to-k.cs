public class Solution {
    public int MinOperations(int[] nums, int k) {
        int m = nums.Min();
        if (m < k) return -1;
        int n = nums.Length;
        HashSet<int> h = new HashSet<int>();
        for (int i = 0; i < n; i++)
            h.Add(nums[i]);
        int ans = h.Count;
        if (h.Contains(k))
            return ans - 1;
        else
            return ans;
    }
}