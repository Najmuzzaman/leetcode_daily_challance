public class Solution {
    public int FindMinArrowShots(int[][] points) {
        int n = points.Length;
        if (points == null || n == 0) return 0;

        // Sort balloons based on their end points
        Array.Sort(points, (a, b) => (long)a[1] - b[1] > 0 ? 1 : ((long)a[1] - b[1] < 0 ? -1 : 0));


        int arrows = 1;
        int end = points[0][1];

        // Iterate through balloons and count arrows
        for (int i = 1; i < n; i++) 
        {
            if ( (long) points[i][0] > end)  // Current balloon starts after previous end
            {
                arrows++;
                end = points[i][1];
            }
        }

        return arrows;
    }
}