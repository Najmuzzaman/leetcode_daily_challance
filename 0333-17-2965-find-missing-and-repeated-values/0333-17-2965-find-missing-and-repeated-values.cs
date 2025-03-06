public class Solution {
    public int[] FindMissingAndRepeatedValues(int[][] grid) {
        int n = grid.Length;
        HashSet<int> seen = new HashSet<int>();
        int repeated = 0;

        // Find the repeated value
        foreach (var row in grid)
        {
            foreach (var num in row)
            {
                if (seen.Contains(num))
                {
                    repeated = num;
                    break;
                }
                seen.Add(num);
            }
            if (repeated != 0) break;
        }

        // Calculate the missing value
        int totalSum = n * n * (n * n + 1) / 2;
        int gridSum = grid.Sum(row => row.Sum());
        int missing = totalSum - gridSum + repeated;

        return new int[] { repeated, missing };
    }
}