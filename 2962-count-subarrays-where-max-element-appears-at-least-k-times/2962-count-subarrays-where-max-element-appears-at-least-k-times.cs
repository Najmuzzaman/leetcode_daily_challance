public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        long max_num = nums.Max();
        long count = 0;
        long left = 0, right = 0, result = 0;
        int n=nums.Length;
        
        while (right < n || left > right) {
            if (nums[(int)right] == max_num) count++;
            
            while (count >= k) {
                if (nums[(int)left] == max_num) count--;
                left++;
                result += n - right;
            }
            
            right++;
        }
        
        return result;
    }
}