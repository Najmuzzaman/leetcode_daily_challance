public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int left = 1, right = 1;
        int[] ans = new int[n];

        for(int i=0;i<n;i++){
            ans[i] = left;
            left *= nums[i];
        }
        for(int i=n-1;i>=0;i--){
            ans[i] *= right;
            right *= nums[i];
        }
        return ans;
    }
}