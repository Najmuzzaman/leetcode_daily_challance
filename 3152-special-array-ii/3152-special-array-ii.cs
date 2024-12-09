public class Solution {
    public bool[] IsArraySpecial(int[] nums, int[][] queries) {
        int n = nums.Length;
        int[] specialTill = new int[n];
        
        for (int i = 1; i < n; i++)
        {
            if ((nums[i - 1] % 2) == (nums[i] % 2))
                specialTill[i] = 1;
        }
        
        int[] prefixSpecial = new int[n + 1];
        for (int i = 1; i <= n; i++)
            prefixSpecial[i] = prefixSpecial[i - 1] + specialTill[i - 1];

        bool[] result = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int fromi = queries[i][0];
            int toi = queries[i][1];
            
            if (prefixSpecial[toi + 1] - prefixSpecial[fromi + 1] == 0)
                result[i] = true;
            else
                result[i] = false;
        }
        
        return result;
    }
}