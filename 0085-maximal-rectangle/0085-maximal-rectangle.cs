public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if (matrix == null || matrix.Length == 0)
            return 0;

        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int[] heights = new int[cols];
        int maxArea = 0;

        for (int i = 0; i < rows; i++)
        {
            // Update heights array based on current row
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == '1')
                    heights[j]++;
                else
                    heights[j] = 0;
            }

            // Calculate area of largest rectangle in histogram
            maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
        }

        return maxArea;
    }
    public static int LargestRectangleArea(int[] heights)
    {
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;

        for (int i = 0; i <= heights.Length; i++)
        {
            int h = (i == heights.Length) ? 0 : heights[i];
            if (stack.Count == 0 || h >= heights[stack.Peek()])
            {
                stack.Push(i);
            }
            else
            {
                int tp = stack.Pop();
                maxArea = Math.Max(maxArea, heights[tp] * (stack.Count == 0 ? i : i - stack.Peek() - 1));
                i--;
            }
        }

        return maxArea;
    }
}