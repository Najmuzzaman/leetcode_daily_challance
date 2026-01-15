public class Solution {
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        Array.Sort(hBars);
        Array.Sort(vBars);
        int side = Math.Min(MaxSpan(hBars), MaxSpan(vBars));
        return side * side;
    }
    private int MaxSpan(int[] bars) {
        int res = 1, streak = 1;
        for (int i = 1; i < bars.Length; i++) {
            if (bars[i] == bars[i - 1] + 1) {
                streak++;
                res = Math.Max(res, streak);
            } else {
                streak = 1;
            }
        }
        return res + 1;
    }
}