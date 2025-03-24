public class Solution {
    public int CountDays(int days, int[][] meetings) {
         Array.Sort(meetings, (a, b) => a[0] - b[0]);
        List<int[]> m = new List<int[]>();

        foreach (var meet in meetings) 
        {
            if (m.Count == 0 || meet[0] > m[^1][1])
                m.Add(meet);
            else 
                m[^1][1] = Math.Max(m[^1][1], meet[1]);
            
        }

        int count = m[0][0] - 1;
        for (int i = 1; i < m.Count; i++)
            count += m[i][0] - m[i - 1][1] - 1;
        

        count += days - m[^1][1];
        return count;
    }
}