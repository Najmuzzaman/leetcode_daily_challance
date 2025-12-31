public class Solution {
    private (int, int)[] dir = new (int, int)[4] {(1, 0), (-1, 0), (0, 1), (0, -1)};
    public int LatestDayToCross(int row, int col, int[][] cells) {
        int left = 1;
        int right = row * col;
        while (left < right)
        {
            var mid = right - (right - left) / 2;
            if (CanCross(row, col, cells, mid))
                left = mid;
            else
                right = mid - 1;
        }
        return left;
    }  

    private bool CanCross(int r, int c, int[][] cells, int day)
    {
        int[,] g = new int[r, c];
        for (int i = 0; i < day; i++)
            g[cells[i][0] - 1, cells[i][1] - 1] = 1;
        
        var q = new Queue<(int, int)>();
        for (int i = 0; i < c; i++)
        {
            if (g[0, i] == 0)
            {
                q.Enqueue((0, i));
                g[0, i] = -1;
            }
        }
        while (q.Count != 0)
        {
            var curr = q.Dequeue();
            var row = curr.Item1;
            var col = curr.Item2;
            if (row == r - 1) return true;
            foreach (var d in dir)
            {
                var newR = row + d.Item1;
                var newC = col + d.Item2;
                if (newR >= 0 && newR < r && newC >= 0 && newC < c && g[newR, newC] == 0)
                {
                    g[newR, newC] = -1;
                    q.Enqueue((newR, newC));
                }
            }
        }
        return false;
    }
}