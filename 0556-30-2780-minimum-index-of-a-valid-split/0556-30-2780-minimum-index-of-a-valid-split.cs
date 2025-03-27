public class Solution {
    public int MinimumIndex(IList<int> nums) 
    {
        Dictionary<int, int> m = new(), n = new();
        foreach (int num in nums) 
            m[num] = m.GetValueOrDefault(num, 0) + 1;
        int p = nums.Count;
        for(int i = 0; i < p - 1; i++) 
        {
            n[nums[i]] = n.GetValueOrDefault(nums[i], 0) + 1;
            int f1 = n[nums[i]], f2 = m[nums[i]] - f1;
            if (f1 * 2 > i + 1 && f2 * 2 > p - i - 1) return i;
        }
        return -1;
    }
}