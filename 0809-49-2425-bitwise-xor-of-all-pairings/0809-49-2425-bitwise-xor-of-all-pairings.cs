public class Solution {
    public int XorAllNums(int[] nums1, int[] nums2) {
        int n = nums1.Length;
        int m = nums2.Length;
        int res=0;
        if(n % 2 == 0 && m % 2 == 0) return 0;
        if(m % 2 != 0)
            foreach(int x in nums1) 
                res ^= x;
        if(n % 2 != 0)
            foreach(int x in nums2) 
                res ^= x;
        return res;
    }
}