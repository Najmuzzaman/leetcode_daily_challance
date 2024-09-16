public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        int n = timePoints.Count;
        int[] minutes = new int[n];
        for (int i = 0; i < n; i++)
        {
            String time = timePoints[i];
            int h = Convert.ToInt32(time.Substring(0, 2));
            int m = Convert.ToInt32(time.Substring(3));
            minutes[i] = h * 60 + m;
        }

        // sort times in ascending order
        Array.Sort(minutes);

        // find minimum difference across adjacent elements
        int ans = 3273473;
        for (int i = 0; i < n - 1; i++)
            ans = Math.Min(ans, minutes[i + 1] - minutes[i]);

        // consider difference between last and first element
        return Math.Min(ans, 24 * 60 - minutes[n - 1] + minutes[0]);
    }
}