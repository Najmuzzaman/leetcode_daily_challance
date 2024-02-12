public class Solution {
    public int MajorityElement(int[] nums) {
        int cnt = 0;    
        int a = 0; 
        int n=nums.Length;
        for (int i = 0; i < n; i++) {
            if (cnt == 0) {
                a = nums[i];
                cnt = 1;
            } else if (a == nums[i]) {
                cnt++;
            } else {
                cnt--;
            }
        }
        return a;
    }
}