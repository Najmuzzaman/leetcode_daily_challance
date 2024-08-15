public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        Array.Sort(nums);
        int n = nums.Length;
        int low = 0, high = nums[n - 1] - nums[0];

        while (low < high) {
            int mid = low + (high - low) / 2;
            if (countPairs(n,nums, mid) < k) low = mid + 1;
            else high = mid;
        }

        return low;
    }

    private int countPairs(int n, int[] nums, int maxDistance) {
        int count = 0, j = 0;
        for (int i = 0; i < n; ++i) {
            while (j < n && nums[j] - nums[i] <= maxDistance) ++j;
            count += j - i - 1;
        }
        return count;
    }
}