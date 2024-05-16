public class Solution {
    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        int n = grid.Count;
        bool BoundsCheck(int r, int c) => r >= 0 && c >= 0 && r < n && c < n;

        var q = new Deque<(int, int, int)>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    q.AddToBack((i, j, 1));
                }
                grid[i][j]--;
            }
        }

        while (q.Count > 0) {
            var (i, j, safety) = q.RemoveFromFront();
            var expand = new (int, int)[] { (i+1, j), (i-1, j), (i, j+1), (i, j-1) };
            foreach (var (r, c) in expand) {
                if (BoundsCheck(r, c) && grid[r][c] == -1) {
                    grid[r][c] = safety;
                    q.AddToBack((r, c, safety + 1));
                }
            }
        }

        int minSafety = grid[0][0];
        q.AddToBack((0, 0, grid[0][0]));
        while (q.Count > 0) {
            var (i, j, safety) = q.RemoveFromFront();
            minSafety = Math.Min(minSafety, safety);
            if (i == n - 1 && j == n - 1) break;
            var expand = new (int, int)[] { (i+1, j), (i-1, j), (i, j+1), (i, j-1) };
            foreach (var (r, c) in expand) {
                if (BoundsCheck(r, c) && grid[r][c] != -1) {
                    int currentSafety = grid[r][c];
                    grid[r][c] = -1;
                    if (currentSafety < minSafety) {
                        q.AddToBack((r, c, currentSafety));
                    } else {
                        q.AddToFront((r, c, currentSafety));
                    }
                }
            }
        }

        return minSafety;
    }
    
    public class Deque<T> 
    {
        LinkedList<T> list = new LinkedList<T>();
        public void AddToFront(T item) {
            list.AddFirst(item);
        }
        public void AddToBack(T item) {
            list.AddLast(item);
        }
        public T RemoveFromFront() {
            var item = list.First.Value;
            list.RemoveFirst();
            return item;
        }
        public int Count => list.Count;
    }
}