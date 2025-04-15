public class Solution {
    public long GoodTriplets(int[] nums1, int[] nums2) {
       int n = nums1.Length;
        var indexMap = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            indexMap[nums1[i]] = i;
        }

        int[] idxArr = new int[n];
        for (int i = 0; i < n; i++)
        {
            idxArr[i] = indexMap[nums2[i]];
        }

        // Fenwick Tree to count number of indices < current
        var fenwick = new FenwickTree(n);
        long total = 0;

        for (int i = 0; i < n; i++)
        {
            int idx = idxArr[i];
            int left = fenwick.Query(idx); // count of elements < idx
            int right = (n - 1 - idx) - (fenwick.Count - left); // count of elements > idx
            total += (long)left * right;
            fenwick.Update(idx, 1);
        }

        return total; 
    }
    private class FenwickTree
    {
        private int[] tree;
        public int Count { get; private set; }

        public FenwickTree(int size)
        {
            tree = new int[size + 2];
            Count = 0;
        }

        public void Update(int i, int delta)
        {
            Count += delta;
            i++;
            while (i < tree.Length)
            {
                tree[i] += delta;
                i += i & -i;
            }
        }

        public int Query(int i)
        {
            int sum = 0;
            i++;
            while (i > 0)
            {
                sum += tree[i];
                i -= i & -i;
            }
            return sum;
        }
    }
}