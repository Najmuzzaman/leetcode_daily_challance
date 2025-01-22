public class Solution {
    public int[][] HighestPeak(int[][] isWater) {
         int r = isWater.Length;
        int c = isWater[0].Length;
        int[] d = {0, 1, 0, -1, 0};
        int[][] H = new int[r][];
        for (int i = 0; i < r; i++) {
            H[i] = new int[c];
            Array.Fill(H[i], -1);
        }
        Queue<(int, int)> q = new Queue<(int, int)>();
        for (int i = 0; i < r; i++) {
            for (int j = 0; j < c; j++) {
                if (isWater[i][j] == 1) {
                    H[i][j] = 0;
                    q.Enqueue((i, j));
                }
            }
        }
        int h = 0;
        while (q.Count > 0) {
            int qz = q.Count;
            for (int a = 0; a < qz; a++) {
                (int i, int j) = q.Dequeue();
                for (int b = 0; b < 4; b++) {
                    int s = i + d[b];
                    int t = j + d[b + 1];
                    if (s < 0 || s >= r || t < 0 || t >= c || H[s][t] != -1) {
                        continue;
                    }
                    q.Enqueue((s, t));
                    H[s][t] = h + 1;
                }
            }
            h++;
        }
        return H;
    }
}