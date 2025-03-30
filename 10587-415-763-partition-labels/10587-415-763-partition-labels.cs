public class Solution {
    public IList<int> PartitionLabels(string s) {
        var lastIndex = new Dictionary<char, int>();

        // Store the last occurrence of each character
        for (int i = 0; i < s.Length; i++) {
            lastIndex[s[i]] = i;
        }

        var result = new List<int>();
        int start = 0, end = 0;

        // Iterate through the string to determine partitions
        for (int i = 0; i < s.Length; i++) {
            end = Math.Max(end, lastIndex[s[i]]);
            if (i == end) {
                result.Add(end - start + 1);
                start = i + 1;
            }
        }
        return result;
    }
}