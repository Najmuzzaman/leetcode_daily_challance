public class Solution {
    public int ShortestSubarray(int[] nums, int k) {
        int n = nums.Length;
        int ans = int.MaxValue;
        long sum = 0;        
        var prefixHeap = new SortedSet<(long Sum, int Index)>();        
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];

            if (sum >= k)
                ans = Math.Min(ans, i + 1);

            while (prefixHeap.Count > 0 && sum - prefixHeap.Min.Sum >= k)
            {
                ans = Math.Min(ans, i - prefixHeap.Min.Index);
                prefixHeap.Remove(prefixHeap.Min);
            }
            prefixHeap.Add((sum, i));
        }
        return ans == int.MaxValue ? -1 : ans;
    }
}