public class Solution {
    public int FindFinalValue(int[] nums, int original) {
        int n=nums.Length;
        for(int i= 0 ; i < n ;i++ ) {
            if(nums.Contains(original)) {
                original += original;
            }
            else break;
        }
      return original;
    }
}