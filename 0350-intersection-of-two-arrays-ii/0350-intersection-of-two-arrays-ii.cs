public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        int[] first = new int[1001];
        List<int> ans = new List<int>();

        foreach(int a in nums1)
            first[a]++;
        foreach(int a in nums2) 
        {
            if (first[a] > 0) 
            {
                ans.Add(a);
                first[a]--;
            }
        }
        return ans.ToArray();
    }
}