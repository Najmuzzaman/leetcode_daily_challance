public class Solution {
    public string SmallestNumber(string pattern) {
        int n = pattern.Length;
        StringBuilder result = new StringBuilder();
        int[] stack = new int[n + 1];
        int index = 0;

        for (int i = 0; i <= n; i++) {
            stack[index++] = i + 1;

            if (i == n || pattern[i] == 'I') {
                while (index > 0) {
                    result.Append(stack[--index]);
                }
            }
        }

        return result.ToString();
    }
}