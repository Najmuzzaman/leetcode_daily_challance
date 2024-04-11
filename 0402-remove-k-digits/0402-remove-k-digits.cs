public class Solution {
    public string RemoveKdigits(string num, int k) {
        if (num.Length == k) return "0"; // If all digits are removed        
        Stack<char> stack = new Stack<char>();        
        foreach (char digit in num) {
            while (k > 0 && stack.Count > 0 && stack.Peek() > digit) {
                stack.Pop(); // Remove larger digits from the stack
                k--;
            }
            stack.Push(digit);
        }        
        // Remove remaining largest digits
        while (k > 0) {
            stack.Pop();
            k--;
        }        
        // Build the result string
        char[] resultArray = new char[stack.Count];
        for (int i = stack.Count - 1; i >= 0; i--) {
            resultArray[i] = stack.Pop();
        }        
        // Skip leading zeros
        int startIndex = 0;
        while (startIndex < resultArray.Length && resultArray[startIndex] == '0') {
            startIndex++;
        }
        // If all digits are removed, return "0"
        if (startIndex == resultArray.Length) return "0";
        
        return new string(resultArray, startIndex, resultArray.Length - startIndex);
    }
}