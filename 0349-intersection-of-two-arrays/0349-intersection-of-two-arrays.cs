public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
         Array.Sort(nums1);
         Array.Sort(nums2);
         int n = nums1.Length;
         int m = nums2.Length;
         int i = 0, j = 0;
         HashSet<int> l = new HashSet<int>();
         while (i < n && j < m)
         {
             if (nums1[i] == nums2[j])
             {
                 l.Add(nums1[i]);
                 i++;
                 j++;
             }
             else if (nums1[i] < nums2[j])
                 i++;
             else
                 j++;
         }
         return l.ToArray();        
    }
}