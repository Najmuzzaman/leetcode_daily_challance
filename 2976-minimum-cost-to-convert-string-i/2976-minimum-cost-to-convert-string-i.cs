public class Solution {
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
         int n = source.Length;

        // Create a mapping of character changes for quick lookup
        long[,] dp = new long[26, 26]; // Assuming only lowercase English letters
        for (int i = 0; i < original.Length; i++)
        {
            int origIdx = original[i] - 'a';
            int changedIdx = changed[i] - 'a';

            // Update the minimum cost between characters
            if(dp[origIdx, changedIdx]!=0)
                dp[origIdx, changedIdx] = Math.Min(dp[origIdx, changedIdx], cost[i]);
            else
                dp[origIdx, changedIdx] = cost[i];
        }

        // Floyd-Warshall algorithm to compute minimum costs
        for (int k = 0; k < 26; k++)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (dp[i, k] != 0 && dp[k, j] != 0)
                    {
                        if (dp[i, j] == 0)
                            dp[i, j] = dp[i, k] + dp[k, j];
                        else
                            dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k, j]);
                    }
                }
            }
        }        

        long totalCost = 0;
        char[] sourceArray = source.ToCharArray();

        for (int i = 0; i < n; i++)
        {
            char targetChar = target[i];

            if (sourceArray[i] != targetChar)
            {
                int sourceIdx = sourceArray[i] - 'a';
                int targetIdx = targetChar - 'a';

                if (dp[sourceIdx, targetIdx] == 0)
                {
                    return -1; // Impossible to convert
                }

                totalCost += dp[sourceIdx, targetIdx];
                sourceArray[i] = targetChar;
            }
        }

        return totalCost;
    }
}