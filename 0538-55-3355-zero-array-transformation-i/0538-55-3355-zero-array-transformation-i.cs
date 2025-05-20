public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        var prefix = new int[nums.Length + 1];
        foreach (var query in queries) 
        {
            prefix[query[0]]++;
            prefix[query[1] + 1]--;
        }
        var canDecrease = 0;
        for (var i = 0; i < nums.Length; i++) 
        {
            canDecrease += prefix[i];
            if (canDecrease < nums[i])
                return false;
        }
        return true;
    }
}