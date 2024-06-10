public class Solution {
    public int HeightChecker(int[] heights) {
        int n = heights.Length;
        int[] h = (int[])heights.Clone();
        Array.Sort(h);
        int cnt = 0;
        for(int i=0;i<n;i++)
            if (heights[i] != h[i]) cnt++;
        return cnt;
    }
}