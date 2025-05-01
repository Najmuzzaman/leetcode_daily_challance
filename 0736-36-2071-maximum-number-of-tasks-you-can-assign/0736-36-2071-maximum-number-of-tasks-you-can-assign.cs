public class Solution {
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength) {
         Array.Sort(tasks);
        Array.Sort(workers);

        int n = tasks.Length, m = workers.Length;

        bool CanAssign(int k) {
            int p = pills;
            var candidateWorkers = new LinkedList<int>();
            int w = m - 1;

            for (int t = k - 1; t >= 0; t--) {
                while (w >= m - k && workers[w] + strength >= tasks[t]) {
                    candidateWorkers.AddFirst(workers[w]);
                    w--;
                }

                if (candidateWorkers.Count == 0)
                    return false;

                if (candidateWorkers.Last.Value >= tasks[t]) {
                    candidateWorkers.RemoveLast();
                }
                else {
                    if (p == 0)
                        return false;
                    p--;
                    candidateWorkers.RemoveFirst();
                }
            }

            return true;
        }

        int low = 0, high = Math.Min(n, m), answer = 0;

        while (low <= high) {
            int mid = (low + high) / 2;
            if (CanAssign(mid)) {
                answer = mid;
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }

        return answer;
    }
}