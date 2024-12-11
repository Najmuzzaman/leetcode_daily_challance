public class Solution {
    public int MaximumBeauty(int[] nums, int k) {
        if (nums.Length == 1) return 1;

        int maxBeauty = 0;
        int maxValue = 0;
        maxValue = nums.Max();
        
        int[] count = new int[maxValue + 2];

        foreach (int num in nums)
        {
            count[Math.Max(num - k, 0)]++;
            if (num + k + 1 <= maxValue)
            {
                count[num + k + 1]--;
            }
        }

        int currentSum = 0;
        foreach (int val in count)
        {
            currentSum += val;
            maxBeauty = Math.Max(maxBeauty, currentSum);
        }

        return maxBeauty;
    }
}