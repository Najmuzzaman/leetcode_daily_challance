public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {       
        int n = nums.Length;
       
        int sum = nums[0];
        for (int i = 1; i < n; i++) {
            if (nums[i] == nums[i - 1] && nums[i] == 0)
                return true;
            sum += nums[i];            
            if (sum % k == 0) 
                return true;            
            int ins = 0;
            int s = sum;            
            while ((i - ins) > 1 && s >= k) {
                s -= nums[ins++];
                
                if (s % k == 0) 
                    return true;
            }
        }
        
        return false;
    }
}