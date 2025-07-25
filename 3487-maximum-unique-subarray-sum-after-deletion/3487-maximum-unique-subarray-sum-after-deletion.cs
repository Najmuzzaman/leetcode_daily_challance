public class Solution {
    public int MaxSum(int[] nums) {
        HashSet<int> nu = new HashSet<int>();
        foreach (int num in nums) 
            if (num > 0) 
                nu.Add(num);
        if (nu.Count == 0) 
            return nums.Max();
        return nu.Sum();
    }
}