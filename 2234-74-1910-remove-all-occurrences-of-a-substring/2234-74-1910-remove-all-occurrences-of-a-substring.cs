public class Solution {
    public string RemoveOccurrences(string s, string part) {
        char[] input = s.ToCharArray();
        char[] target = part.ToCharArray();
        char[] resultStack = new char[input.Length];
        int stackSize = 0;
        int targetLength = target.Length;
        char targetEndChar = target[targetLength - 1];

        foreach (char currentChar in input)
        {
            resultStack[stackSize++] = currentChar;

            if (currentChar == targetEndChar && stackSize >= targetLength)
            {
                int i = stackSize - 1, j = targetLength - 1;

                while (j >= 0 && resultStack[i] == target[j])
                {
                    i--;
                    j--;
                }

                if (j < 0)
                {
                    stackSize = i + 1;
                }
            }
        }

        return new string(resultStack, 0, stackSize);
    }
}