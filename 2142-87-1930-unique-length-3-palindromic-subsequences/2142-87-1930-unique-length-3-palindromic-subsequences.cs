public class Solution {
    public int CountPalindromicSubsequence(string s) {
         int[] first = new int[26];
        int[] last = new int[26];
        int result = 0;

        // Initialize first with a very large value and last with -1
        Array.Fill(first, int.MaxValue);
        Array.Fill(last, -1);

        // Populate first and last arrays
        for (int i = 0; i < s.Length; i++)
        {
            int charIndex = s[i] - 'a';
            first[charIndex] = Math.Min(first[charIndex], i);
            last[charIndex] = i;
        }

        // Iterate over each character
        for (int i = 0; i < 26; i++)
        {
            if (first[i] < last[i])
            {
                // Use a HashSet to count unique characters between first[i] and last[i]
                HashSet<char> uniqueChars = new HashSet<char>();
                for (int j = first[i] + 1; j < last[i]; j++)
                {
                    uniqueChars.Add(s[j]);
                }
                result += uniqueChars.Count;
            }
        }

        return result;
    }
}