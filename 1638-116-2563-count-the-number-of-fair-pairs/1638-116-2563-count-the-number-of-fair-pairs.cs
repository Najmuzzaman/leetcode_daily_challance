public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums);
        long ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // Assume we have picked nums[i] as the first pair element.

            // `low` indicates the number of possible pairs with sum < lower.
            long low = LowerBound(nums, i + 1, nums.Length - 1, lower - nums[i]);

            // `high` indicates the number of possible pairs with sum <= upper.
            long high = LowerBound(nums, i + 1, nums.Length - 1, upper - nums[i] + 1);

            // Their difference gives the number of elements with sum in the given range.
            ans += (high - low);
        }
        return ans;
    }
    private long LowerBound(int[] nums, int low, int high, int element)
    {
        while (low <= high)
        {
            int mid = low + ((high - low) / 2);
            if (nums[mid] >= element)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return low;
    }
}