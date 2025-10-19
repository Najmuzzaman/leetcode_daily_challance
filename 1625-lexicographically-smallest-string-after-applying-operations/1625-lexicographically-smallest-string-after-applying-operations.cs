public class Solution {
    public string FindLexSmallestString(string s, int a, int b) {
        HashSet<string> seen = new HashSet<string>();
        Queue<string> queue = new Queue<string>();
        string result = s;

        queue.Enqueue(s);
        seen.Add(s);

        while (queue.Count > 0) {
            string current = queue.Dequeue();

            // Update the result to be the lexicographically smallest string found
            if (string.Compare(current, result) < 0) {
                result = current;
            }

            // Apply operation 1: Add 'a' to all odd indices
            char[] chars = current.ToCharArray();
            for (int i = 1; i < chars.Length; i += 2) {
                chars[i] = (char)((chars[i] - '0' + a) % 10 + '0');
            }
            string newString1 = new string(chars);
            if (!seen.Contains(newString1)) {
                seen.Add(newString1);
                queue.Enqueue(newString1);
            }

            // Apply operation 2: Rotate the string by 'b' positions
            string newString2 = RotateString(current, b);
            if (!seen.Contains(newString2)) {
                seen.Add(newString2);
                queue.Enqueue(newString2);
            }
        }

        return result;
    }

    private string RotateString(string s, int b) {
        int n = s.Length;
        b = b % n;
        return s.Substring(n - b) + s.Substring(0, n - b);
    }
}