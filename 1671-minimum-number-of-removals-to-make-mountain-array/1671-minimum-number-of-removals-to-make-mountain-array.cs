public class Solution {
    public int MinimumMountainRemovals(int[] nums) {
        int n = nums.Length;
        int[] lis = LIS(nums);

        Array.Reverse(nums);
        int[] lds = LIS(nums);
        Array.Reverse(lds);
        int ans = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            if (lis[i] > 1 && lds[i] > 1)
            {
                ans = Math.Min(ans, n - lis[i] - lds[i] + 1);
            }
        }
        return ans;
    }
    int[] LIS(int[] s)
    {
        int n=s.Length;
        int[] lisLen = new int[n];
        Array.Fill(lisLen,1);
        List<int> lis = new List<int> { s[0] };
        for (int i = 1; i < n; i++)
        {
            int index = lis.BinarySearch(s[i]);
            if (index < 0)
                index = ~index;

            if(index==lis.Count)
                lis.Add(s[i]);
            else
                lis[index] = s[i];

            lisLen[i] = lis.Count;
        }
        return lisLen;
    }
}