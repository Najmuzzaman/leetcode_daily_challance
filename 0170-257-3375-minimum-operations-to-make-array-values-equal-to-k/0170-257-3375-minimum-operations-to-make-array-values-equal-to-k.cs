public class Solution {
    public int MinOperations(int[] nums, int k) {
        int n = nums.Length;
        HashSet<int> h = new HashSet<int>();
        for (int i = 0; i < n; i++)
        {
            if (k < nums[i])
                h.Add(nums[i]);
            else if (k > nums[i])
                return -1;
        }
        return h.Count;
    }
}