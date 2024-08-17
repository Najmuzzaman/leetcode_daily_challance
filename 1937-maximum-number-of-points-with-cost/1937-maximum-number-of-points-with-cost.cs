public class Solution {
    public long MaxPoints(int[][] points) 
    {
        int m = points.Length;
        int n = points[0].Length;
        
        long[] prevRow = Array.ConvertAll(points[0], x => (long)x);
        
        for (int i = 1; i < m; ++i) 
        {
            long[] currRow = new long[n];
            long[] leftMax = new long[n];
            long[] rightMax = new long[n];
            
            // Fill leftMax array
            leftMax[0] = prevRow[0];
            for (int j = 1; j < n; ++j) 
                leftMax[j] = Math.Max(leftMax[j - 1], prevRow[j] + j);
            
            
            // Fill rightMax array
            rightMax[n - 1] = prevRow[n - 1] - (n - 1);
            for (int j = n - 2; j >= 0; --j) 
                rightMax[j] = Math.Max(rightMax[j + 1], prevRow[j] - j);
            
            
            // Compute current row's max points
            for (int j = 0; j < n; ++j) 
                currRow[j] = Math.Max(leftMax[j] - j, rightMax[j] + j) + points[i][j];
            
            
            // Move to the next row
            prevRow = currRow;
        }
        
        return prevRow.Max();
    }
}