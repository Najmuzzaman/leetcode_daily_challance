public class Solution {
    public int MinDeletionSize(string[] strs) {
        int rows = strs.Length;
        int cols = strs[0].Length;
        int[] dp = new int[cols];
        Array.Fill(dp, 1);
        int maxLen = 1;
        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < j; i++)
            {
                if (IsValid(strs, i, j, rows))
                    dp[j] = Math.Max(dp[j], dp[i] + 1);                
            }
            maxLen = Math.Max(maxLen, dp[j]);
        }
        return cols - maxLen;
    }
    private bool IsValid(string[] strs, int a, int b, int rows)
    {
        for (int i = 0; i < rows; i++)
            if (strs[i][a] > strs[i][b])
                return false;
        return true;
    }
}