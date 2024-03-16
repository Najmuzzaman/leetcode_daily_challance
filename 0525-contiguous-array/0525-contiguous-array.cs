public class Solution {
    public int FindMaxLength(int[] nums) {
        int ans = 0;
        Dictionary<int, int> SumMap = new Dictionary<int, int> {{0, -1}};
        int n=nums.Length;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            count += (nums[i] == 0) ? 1 : -1;            
            if (SumMap.ContainsKey(count))
                ans = Math.Max(ans, i - SumMap[count]);
            else
                SumMap.Add(count, i);
        }        
        return ans;
    }
}