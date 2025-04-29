public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        long res = 0;
        int max_element = 0, maxi_count = 0;
        int n=nums.Length;
        for (int i = 0; i < n; i++)
            max_element = Math.Max(max_element, nums[i]);
        

        for (int right = 0, left = 0; right < n; right++) {
            if (nums[right] == max_element)
                maxi_count++;
            while (maxi_count == k) {
                res += n - right;
                if (nums[left] == max_element)
                    maxi_count--;
                left++;
            }
        }

        return res;
    }
}