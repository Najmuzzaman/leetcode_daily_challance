public class Solution {
    public int[] FrequencySort(int[] nums) {
        int n = nums.Length;
        int[] mp = new int[201];

        // Calculate frequencies of characters
        foreach (int num in nums)
        {
            mp[num + 100]++;
        }

        // Sort frequencies in ascending order
        Array.Sort(nums, (a, b) => {
            int freqDiff = mp[a + 100] - mp[b + 100]; // Compare frequencies in ascending order
            return freqDiff == 0 ? b - a : freqDiff; // If frequencies are equal, sort by character value
        });

        return nums;
    }
}
