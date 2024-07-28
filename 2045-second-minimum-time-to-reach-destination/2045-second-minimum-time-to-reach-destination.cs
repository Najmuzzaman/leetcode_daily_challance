public class Solution {
    public int SecondMinimum(int n, int[][] edges, int time, int change) {
         var G = new List<List<int> >(n);
        for (int i = 0; i < n; i++)
        {
            G.Add(new List<int>());
        }
        foreach (var edge in edges)
        {
            G[edge[0] - 1].Add(edge[1] - 1);
            G[edge[1] - 1].Add(edge[0] - 1);
        }

        var Q = new Queue<int>();
        var seen = new bool[n * 2];
        Q.Enqueue(0);
        seen[0] = true;

        int maxLength = int.MaxValue;
        int wave = 0;
        bool odd = true;
        int firstPathLength = -1;

        while (Q.Count > 0)
        {
            int thisRound = Q.Count;
            odd = !odd;
            for (int i = 0; i < thisRound; i++)
            {
                int pos = Q.Dequeue();

                if (pos == n - 1)
                {
                    if (firstPathLength == -1)
                    {
                        firstPathLength = wave;
                        maxLength = wave + 2;
                        continue;
                    }
                    else
                    {
                        maxLength = Math.Min(maxLength, wave);
                        return howLong(maxLength, time, change);
                    }
                }

                foreach (var next in G[pos])
                {
                    if (seen[next * 2 + (odd ? 1 : 0)])
                        continue;

                    seen[next * 2 + (odd ? 1 : 0)] = true;
                    Q.Enqueue(next);
                }
            }
            wave++;

            if (maxLength < wave)
                break;
        }
        return howLong(maxLength, time, change);
    }
    
    static int howLong(int needed, int time, int change) {
        int ans = 0;
        for (int i = 0; i < needed; i++) {
            int turn = ans / change;
            if ((turn % 2) != 0)
                ans += change - (ans % change);

            ans += time;
        }
        return ans;
    }
}