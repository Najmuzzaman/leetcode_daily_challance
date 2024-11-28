public class Solution {
    public int MinimumObstacles(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] directions = new int[][] {
            new int[] { 0, 1 }, new int[] { 0, -1 },
            new int[] { 1, 0 }, new int[] { -1, 0 }
        };


        var pq = new SortedSet<(int obstacles, int x, int y)>();
        int[,] MinObstacles = new int[m,n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                MinObstacles[i, j] = -1;
            }
        }
        MinObstacles[0,0] = 0;
        pq.Add((0, 0, 0));

        var visited = new bool[m, n];

        while (pq.Count > 0)
        {
            var current = pq.Min;
            pq.Remove(current);

            int obstacles = current.obstacles, x = current.x, y = current.y;

            if (x == m - 1 && y == n - 1) return obstacles;


            foreach (var dir in directions)
            {
                int nx = x + dir[0], ny = y + dir[1];
                if (nx >= 0 && ny >= 0 && nx < m && ny < n)
                {
                    if( MinObstacles[nx, ny]==-1)
                    {
                        if (grid[nx][ny] == 1)
                        {
                            MinObstacles[nx,ny] = obstacles + 1;
                            pq.Add((obstacles + 1, nx, ny));
                        }
                        else
                        {
                            MinObstacles[nx, ny] = obstacles;
                            pq.Add((obstacles, nx, ny));
                        }
                    }
                }
            }
        }

        return MinObstacles[m - 1,n - 1];;
    }
}