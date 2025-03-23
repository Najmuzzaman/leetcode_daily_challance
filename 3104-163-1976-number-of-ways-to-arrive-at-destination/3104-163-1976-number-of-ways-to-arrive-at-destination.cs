public class Solution {
    public int CountPaths(int n, int[][] roads) {
        int mod = (int)1e9 + 7;
        List<(int, int)>[] adj = new List<(int, int)>[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new List<(int, int)>();
        }
        
        foreach (var r in roads) {
            adj[r[0]].Add((r[1], r[2]));
            adj[r[1]].Add((r[0], r[2]));
        }
        
        PriorityQueue<(long, int), long> pq = new();
        long[] shortestTime = new long[n];
        Array.Fill(shortestTime, long.MaxValue);
        int[] cnt = new int[n];
        
        shortestTime[0] = 0;
        cnt[0] = 1;
        pq.Enqueue((0, 0), 0);
        
        while (pq.Count > 0) {
            var (time, node) = pq.Dequeue();
            
            if (time > shortestTime[node]) continue;
            
            foreach (var (nbr, rtime) in adj[node]) {
                if (time + rtime < shortestTime[nbr]) {
                    shortestTime[nbr] = time + rtime;
                    cnt[nbr] = cnt[node];
                    pq.Enqueue((shortestTime[nbr], nbr), shortestTime[nbr]);
                } else if (time + rtime == shortestTime[nbr]) {
                    cnt[nbr] = (cnt[nbr] + cnt[node]) % mod;
                }
            }
        }
        
        return cnt[n - 1];
    }
}