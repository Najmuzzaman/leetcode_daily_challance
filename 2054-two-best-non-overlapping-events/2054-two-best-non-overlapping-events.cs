public class Solution {
    public int MaxTwoEvents(int[][] events) {
        int ans = 0;
        int value = 0;
        int n=events.Length;
        List<int[]> dp= new List<int[]>();
        for (int i = 0; i < n; i++)
        {
            int s = events[i][0];
            int e = events[i][1] + 1;
            int v = events[i][2];
            dp.Add(new int[]{ s, 1, v });
            dp.Add(new int[]{ e, 0, v});
        }
        dp.Sort((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0]) );
        foreach (int[] times in dp)
        {
            if (times[1] == 1)
                ans = Math.Max(ans, times[2] + value);
            else
                value = Math.Max(value, times[2]);
        }
        return ans;
    }
}