public class Solution {
    public int MostBooked(int n, int[][] meetings) {
        int[] result = new int[n];
        long[] meet = new long[n];

        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        for (int i = 0; i < meetings.Length; i++) {
            int start = meetings[i][0], end = meetings[i][1];
            bool flag = false;
            int cur_meet = -1;
            long val = long.MaxValue;
            for (int j = 0; j < n; j++) {
                if (meet[j] < val) {
                    val = meet[j];
                    cur_meet = j;
                }
                if (meet[j] <= start) {
                    flag = true;
                    result[j]++;
                    meet[j] = end;
                    break;
                }
            }
            if (!flag) {
                result[cur_meet]++;
                meet[cur_meet] += (end - start);
            }
        }

        int max_meet = -1, ans = -1;
        for (int i = 0; i < n; i++) {
            if (result[i] > max_meet) {
                max_meet = result[i];
                ans = i;
            }
        }
        return ans;
    }
}