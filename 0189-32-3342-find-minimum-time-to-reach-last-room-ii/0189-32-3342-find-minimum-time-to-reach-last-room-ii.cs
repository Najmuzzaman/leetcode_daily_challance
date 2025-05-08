public class Solution {
   private record Step(int Row, int Column, int DurationOfMoveToThisCell, int TimeAtCell);

    // Define possible moves (Up, Down, Left, Right)
    private static readonly int[][] directions = {
        new[] { -1, 0 }, // UP
        new[] { 1, 0 },  // DOWN
        new[] { 0, -1 }, // LEFT
        new[] { 0, 1 }   // RIGHT
    };

    // Grid dimensions
    private int rows;
    private int columns;

    // Start and target coordinates
    private int startRow;
    private int startColumn;
    private int targetRow;
    private int targetColumn;

    public int MinTimeToReach(int[][] moveTime)
    {
        // Check for empty or invalid input grid
        if (moveTime == null || moveTime.Length == 0 || moveTime[0].Length == 0)
        {
            
            return -1; 
        }

        rows = moveTime.Length;
        columns = moveTime[0].Length;

        startRow = 0;
        startColumn = 0;
        targetRow = rows - 1;
        targetColumn = columns - 1;
        
        if (startRow == targetRow && startColumn == targetColumn)
        {
            return 0;
        }

        return DijkstraSearchForPathWithMinTime(moveTime);
    }
    private int DijkstraSearchForPathWithMinTime(int[][] moveTime)
    {
        PriorityQueue<Step, int> minHeapForTime = new PriorityQueue<Step, int>(
            Comparer<int>.Create((x, y) => x - y));

        int[][] minTimeMatrix = new int[rows][];
        for (int r = 0; r < rows; ++r)
        {
            minTimeMatrix[r] = new int[columns];
            Array.Fill(minTimeMatrix[r], int.MaxValue);
        }

        minTimeMatrix[startRow][startColumn] = 0;
        minHeapForTime.Enqueue(new Step(startRow, startColumn, 0, 0), 0);

        while (minHeapForTime.Count > 0)
        {
            Step current = minHeapForTime.Dequeue();

            if (current.TimeAtCell > minTimeMatrix[current.Row][current.Column])
            {
                continue;
            }

            if (current.Row == targetRow && current.Column == targetColumn)
            {
                return current.TimeAtCell;
            }
            foreach (int[] d in directions)
            {
                int nextRow = current.Row + d[0];
                int nextColumn = current.Column + d[1];

                if (!IsInMatrix(nextRow, nextColumn))
                {
                    continue;
                }
                int durationOfMoveToNextCell = 1 + (current.DurationOfMoveToThisCell % 2);

                int timeAtNextCell = durationOfMoveToNextCell + Math.Max(current.TimeAtCell, moveTime[nextRow][nextColumn]);

                // If we found a shorter path to 'nextCell'
                if (minTimeMatrix[nextRow][nextColumn] > timeAtNextCell)
                {
                    minTimeMatrix[nextRow][nextColumn] = timeAtNextCell;
                    minHeapForTime.Enqueue(new Step(nextRow, nextColumn, durationOfMoveToNextCell, timeAtNextCell), timeAtNextCell);
                }
            }
        }
        return minTimeMatrix[targetRow][targetColumn];
    }

    private bool IsInMatrix(int row, int column)
    {
        return row >= 0 && row < rows && column >= 0 && column < columns;
    }
}