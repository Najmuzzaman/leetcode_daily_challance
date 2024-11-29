public class Solution {
    public int MinimumTime(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

        if (grid[1][0] > 1 && grid[0][1] > 1) return -1;

        var pq = new PriorityQueue<(int row, int col, int time), int>();
        pq.Enqueue((0, 0, grid[0][0]), 0);

        bool[,] visited = new bool[m, n];

        int[] dirX = { 1, -1, 0, 0 };
        int[] dirY = { 0, 0, 1, -1 };

        while (pq.Count > 0) 
        {
            var (row, col, time) = pq.Dequeue();

            if (row == m - 1 && col == n - 1) return time;

            if (visited[row, col]) continue;
            visited[row, col] = true;

            for (int d = 0; d < 4; d++) 
            {
                int newRow = row + dirX[d];
                int newCol = col + dirY[d];

                if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && !visited[newRow, newCol]) 
                {
                    int waittime= (grid[newRow][newCol]-time) % 2 ==1?0:1;
                    
                    int nextTime = Math.Max(time + 1, grid[newRow][newCol]+waittime);

                    pq.Enqueue((newRow, newCol, nextTime), nextTime);
                }
            }
        }

        return -1;
    }
    public class PriorityQueue<TElement, TPriority> 
    {
        private readonly SortedDictionary<TPriority, Queue<TElement>> _dict = new();

        public int Count { get; private set; }

        public void Enqueue(TElement element, TPriority priority) 
        {
            if (!_dict.ContainsKey(priority)) 
            {
                _dict[priority] = new Queue<TElement>();
            }
            _dict[priority].Enqueue(element);
            Count++;
        }

        public TElement Dequeue() 
        {
            if (_dict.Count == 0) throw new InvalidOperationException("The queue is empty.");
            var first = _dict.First();
            var element = first.Value.Dequeue();
            if (first.Value.Count == 0) _dict.Remove(first.Key);
            Count--;
            return element;
        }
    }
}