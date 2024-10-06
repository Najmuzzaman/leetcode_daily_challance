public class Solution {
    public int[] GcdValues(int[] nums, long[] queries)
    {
        int n = nums.Max() + 1;
        int[] f = new int[n];  // Previously freq

        // Count frequency of each number in nums
        foreach (int num in nums)
        {
            f[num]++;
        }

        int[] m = new int[n];

        // Calculate how many numbers are divisible by each gcd
        for (int i = 1; i < n; i++)
        {
            for (int j = i; j < n; j += i)
            {
                m[i] += f[j];
            }
        }

        long[] pairs = new long[n];

        // Calculate the number of valid pairs for each gcd
        for (int i = 1; i < n; i++)
        {
            long count = m[i];
            pairs[i] = count * (count - 1) / 2;
        }

        // Exclude invalid pairs
        for (int i = n - 1; i > 0; i--)
        {
            for (int multiple = 2 * i; multiple < n; multiple += i)
            {
                pairs[i] -= pairs[multiple];
            }
        }

        List<Tuple<int, long>> i_c = new List<Tuple<int, long>>();

        for (int i = 1; i < n; i++)
        {
            if (pairs[i] > 0)
            {
                i_c.Add(Tuple.Create(i, pairs[i]));
            }
        }

        List<int> i_values = i_c.Select(x => x.Item1).ToList();  // Previously iValues

        List<long> got = new List<long>();  // Previously psa

        // Build prefix sum array (got) for the counts
        foreach (var (gcd, cnt) in i_c)
        {
            if (got.Count == 0)
            {
                got.Add(cnt);
            }
            else
            {
                got.Add(got.Last() + cnt);
            }
        }

        int[] ans = new int[queries.Length];

        for (int q = 0; q < queries.Length; q++)
        {
            long queryIndex = queries[q];
            int idx = got.BinarySearch(queryIndex+1);

            if (idx < 0)
            {
                idx = ~idx;
            }
            ans[q] = i_values[idx];
        }

        return ans;
    }
}