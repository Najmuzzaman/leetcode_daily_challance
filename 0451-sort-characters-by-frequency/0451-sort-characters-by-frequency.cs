public class Solution {
    public string FrequencySort(string s) {
        // Create a dictionary to store character frequencies
        Dictionary<char, int> frequencyMap = new Dictionary<char, int>();

        // Calculate frequencies of characters
        foreach (char c in s) {
            frequencyMap[c] = frequencyMap.GetValueOrDefault(c, 0) + 1;
        }

        // Find the maximum frequency to determine the size of the bucket array
        int maxFrequency = frequencyMap.Values.Max();

        // Create an array of StringBuilder for buckets, indexed by frequency
        StringBuilder[] buckets = new StringBuilder[maxFrequency + 1];

        // Initialize each bucket
        for (int i = 0; i <= maxFrequency; i++) {
            buckets[i] = new StringBuilder();
        }

        // Populate buckets with characters
        foreach (var kvp in frequencyMap) {
            char c = kvp.Key;
            int frequency = kvp.Value;
            buckets[frequency].Append(c, frequency);
        }

        // Construct the result string by concatenating characters from buckets in reverse order
        StringBuilder result = new StringBuilder();
        for (int i = maxFrequency; i >= 0; i--) {
            result.Append(buckets[i]);
        }

        return result.ToString();
    }
}