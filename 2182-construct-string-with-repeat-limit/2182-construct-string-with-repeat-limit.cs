public class Solution {
    public string RepeatLimitedString(string s, int repeatLimit) {
        int[] freq = new int[26];
        foreach (char c in s) {
            freq[c - 'a']++;
        }

        // Create a max heap (priority queue) to store characters with their frequencies
        PriorityQueue<(char key, int count), char> pq = new PriorityQueue<(char, int), char>(
            Comparer<char>.Create((a, b) => b.CompareTo(a))
        );

        for (int i = 0; i < 26; i++) {
            if (freq[i] > 0) {
                pq.Enqueue(((char)(i + 'a'), freq[i]), (char)(i + 'a'));
            }
        }

        var result = new System.Text.StringBuilder(); // Efficient for string concatenation

        while (pq.Count > 0) {
            var (key, count) = pq.Dequeue();

            // Determine how many characters we can add (up to repeatLimit)
            int useCount = Math.Min(repeatLimit, count);
            result.Append(key, useCount);
            count -= useCount;

            if (count > 0 && pq.Count > 0) {
                // Add one character of the next most frequent character
                var (secondKey, secondCount) = pq.Dequeue();
                result.Append(secondKey);
                if (secondCount > 1) {
                    pq.Enqueue((secondKey, secondCount - 1), secondKey);
                }

                // Reinsert the original character with its remaining count
                pq.Enqueue((key, count), key);
            } else if (count > 0) {
                // If no other character is available to separate, stop to prevent exceeding repeatLimit
                break;
            }
        }

        return result.ToString();
    }
}