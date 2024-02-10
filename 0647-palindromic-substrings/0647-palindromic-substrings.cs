public class Solution {
    public int CountSubstrings(string s) {
        int n = s.Length;
        int count = 0;
        // Create a 2D array to store whether substrings are palindromes
        bool[,] dp = new bool[n, n];

        // Single characters are palindromes
        for (int i = 0; i < n; i++)
        {
            dp[i, i] = true;
            count++;
        }

        // Check for palindromic substrings of length 2
        for (int i = 0; i < n - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                dp[i, i + 1] = true;
                count++;
            }
        }

        // Check for palindromic substrings of length > 2
        for (int length = 3; length <= n; length++)
        {
            for (int i = 0; i < n - length + 1; i++)
            {
                int j = i + length - 1;
                if (s[i] == s[j] && dp[i + 1, j - 1])
                {
                    dp[i, j] = true;
                    count++;
                }
            }
        }

        return count;
    }
}