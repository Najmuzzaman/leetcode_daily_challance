public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) {
        // Split the sentences into words
        string[] words1 = s1.Split(' ');
        string[] words2 = s2.Split(' ');

        // Use a dictionary to count occurrences of words from both sentences
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        // Add words from s1
        foreach (var word in words1) {
            if (wordCount.ContainsKey(word)) {
                wordCount[word]++;
            } else {
                wordCount[word] = 1;
            }
        }

        // Add words from s2
        foreach (var word in words2) {
            if (wordCount.ContainsKey(word)) {
                wordCount[word]++;
            } else {
                wordCount[word] = 1;
            }
        }

        // Find the uncommon words (those that occur exactly once)
        List<string> result = new List<string>();
        foreach (var entry in wordCount) {
            if (entry.Value == 1) {
                result.Add(entry.Key);
            }
        }

        // Convert the result list to an array and return it
        return result.ToArray();
    }
}