public class Solution {
    int caldis(int[] a, int[] b)
    {
        int x =Math.Abs(a[0] - b[0]);
        int y =Math.Abs(a[1] - b[1]);
        return Math.Max(x, y);
    }
    public int MinTimeToVisitAllPoints(int[][] points) {
       int dis=0;
        int n = points.Length;
        for(int i=1;i<n;i++) {
            dis+=caldis(points[i-1],points[i]);
        }
        return dis;
    }
}