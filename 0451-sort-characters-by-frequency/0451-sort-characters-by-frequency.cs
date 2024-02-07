public class Solution {
    public string FrequencySort(string s) {
        int[] mp = new int[128];

        // Calculate frequencies of characters
        foreach (char c in s) {
            mp[c]++;
        }

        // Create an array of characters from ASCII values
        char[] chars = Enumerable.Range(0, 128).Select(i => (char)i).ToArray();

        // Sort characters by frequency in descending order
        Array.Sort(chars, (a, b) => mp[b] - mp[a]);

        // Create a StringBuilder to efficiently build the result string
        StringBuilder result = new StringBuilder();

        // Construct the result string
        foreach (char c in chars) {
            if (mp[c] > 0) {
                result.Append(c, mp[c]);
            }
        }

        return result.ToString();
    }
}