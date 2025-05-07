public class Solution {
    public int MinTimeToReach(int[][] moveTime) {
        int row = moveTime.Length;
        int col = moveTime[0].Length;
        bool[,] visited = new bool[row, col];

        var directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        var pq = new PriorityQueue<(int time, int x, int y), int>();
        pq.Enqueue((0, 0, 0), 0);

        while (pq.Count > 0) {
            var (currTime, x, y) = pq.Dequeue();
            if (x == row - 1 && y == col - 1) {
                return currTime;
            }

            if (visited[x, y]) continue;
            visited[x, y] = true;

            for (int i = 0; i < 4; i++) {
                int nx = x + directions[i, 0];
                int ny = y + directions[i, 1];

                if (nx >= 0 && nx < row && ny >= 0 && ny < col && !visited[nx, ny]) {
                    int nextTime = currTime >= moveTime[nx][ny]
                        ? currTime + 1
                        : moveTime[nx][ny] + 1;

                    pq.Enqueue((nextTime, nx, ny), nextTime);
                }
            }
        }
        return -1;
    }
}