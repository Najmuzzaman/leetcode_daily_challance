public class Solution {
    public int CountMaxOrSubsets(int[] nums) {
                int m = 0;
        foreach (int num in nums)
            m |= num;
        
        return CountSubsets(nums, 0, 0, m);
    }
    private int CountSubsets(int[] nums, int index, int currentOr, int targetOr) 
    {
        if (index == nums.Length)
            return (currentOr == targetOr) ? 1 : 0;
        
        
        int CwO = CountSubsets(nums, index + 1, currentOr, targetOr);

        int Cw = CountSubsets(nums, index + 1, currentOr | nums[index], targetOr);

        return CwO + Cw;
    }
}