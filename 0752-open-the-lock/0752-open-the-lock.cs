public class Solution {
    public int OpenLock(string[] deadends, string target) {
        bool[] visit = new bool[10000]; // 0000~9999
        foreach (string s in deadends) {
            visit[int.Parse(s)] = true;
        }
        if (visit[0]) return -1; // edge case
        Queue<(int, string)> q = new Queue<(int, string)>();
        q.Enqueue((0, "0000"));
        visit[0] = true;
        while (q.Count > 0) {
            (int turn, string s) = q.Dequeue();
            if (s == target) return turn;
            for (int d = 0; d < 4; d++) { // 8 ways of turning
                for (int i = -1; i <= 1; i += 2) {
                    char[] t = s.ToCharArray();
                    char move = t[d];
                    t[d] = (char)(((move - '0' + i + 10) % 10) + '0');
                    int x = int.Parse(new string(t));
                    if (!visit[x]) {
                        q.Enqueue((turn + 1, new string(t)));
                        visit[x] = true;
                    }
                }
            }
        }
        return -1;
    }
}