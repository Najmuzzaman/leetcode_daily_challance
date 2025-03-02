public class Solution {
    public int[][] MergeArrays(int[][] nums1, int[][] nums2) {
         var dict = new Dictionary<int, int>();
        var res = new List<int[]>();
        
        foreach (var num in nums1) {
            if (!dict.ContainsKey(num[0]))
                dict[num[0]] = 0;
            dict[num[0]] += num[1];
        }
        
        foreach (var num in nums2) {
            if (!dict.ContainsKey(num[0]))
                dict[num[0]] = 0;
            dict[num[0]] += num[1];
        }
        
        foreach (var kvp in dict) {
            res.Add(new int[] { kvp.Key, kvp.Value });
        }
        
        res.Sort((a, b) => a[0].CompareTo(b[0]));
        return res.ToArray();
    }
}