public class Solution {
    public long FindScore(int[] nums) {
        var pq = new SortedSet<(int Value, int Index)>();

        int n = nums.Length;
        for (int i = 0; i < n; i++)
            pq.Add((nums[i], i));

        long sum = 0;
        var idxMarked = new HashSet<int>();

        while (pq.Count > 0)
        {
            var smallest = pq.Min;
            pq.Remove(smallest);

            int small = smallest.Value;
            int idx = smallest.Index;

            if (!idxMarked.Contains(idx))
            {
                sum += small;
                idxMarked.Add(idx);

                if (idx + 1 < n && !idxMarked.Contains(idx + 1))
                    idxMarked.Add(idx + 1);

                if (idx - 1 >= 0 && !idxMarked.Contains(idx - 1))
                    idxMarked.Add(idx - 1);
            }
        }

        return sum;
    }
}