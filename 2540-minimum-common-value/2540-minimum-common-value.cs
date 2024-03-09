public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) 
    {
        int n=nums1.Length;
        int m=nums2.Length;
        int i=0, j=0;
        while (i < n && j < m)
        {
            if (nums1[i] == nums2[j])            
                return nums1[i];
             else if (nums1[i] < nums2[j]) 
                i++; 
            else
                j++;  
         }
        return -1;
    }
}