public class Solution {
    public int TrapRainWater(int[][] heightMap) {
        int m = heightMap.Length;
        int n = heightMap[0].Length;

        var boundaryCells = new PriorityQueue<(int height, int row, int col), int>();
        var visited = new bool[m, n];

        // Add boundary cells to the priority queue
        for (int r = 0; r < m; r++)
        {
            foreach (int c in new[] { 0, n - 1 })
            {
                boundaryCells.Enqueue((heightMap[r][c], r, c), heightMap[r][c]);
                visited[r, c] = true;
            }
        }

        for (int c = 0; c < n; c++)
        {
            foreach (int r in new[] { 0, m - 1 })
            {
                boundaryCells.Enqueue((heightMap[r][c], r, c), heightMap[r][c]);
                visited[r, c] = true;
            }
        }

        int trappedWater = 0;
        var directions = new[]
        {
            new[] { 0, 1 },
            new[] { 1, 0 },
            new[] { 0, -1 },
            new[] { -1, 0 }
        };

        while (boundaryCells.Count > 0)
        {
            var (height, i, j) = boundaryCells.Dequeue();

            foreach (var dir in directions)
            {
                int newI = i + dir[0];
                int newJ = j + dir[1];

                if (newI >= 0 && newI < m && newJ >= 0 && newJ < n && !visited[newI, newJ])
                {
                    trappedWater += Math.Max(0, height - heightMap[newI][newJ]);

                    boundaryCells.Enqueue((Math.Max(height, heightMap[newI][newJ]), newI, newJ), Math.Max(height, heightMap[newI][newJ]));

                    visited[newI, newJ] = true;
                }
            }
        }

        return trappedWater;
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

            var firstKey = _dict.First().Key;
            var queue = _dict[firstKey];
            var element = queue.Dequeue();

            if (queue.Count == 0)
            {
                _dict.Remove(firstKey);
            }

            Count--;
            return element;
        }
    }
}