public class Solution {
    public int MaximumGain(string s, int x, int y) {
        int res = 0;
        string top, bot;
        int top_score, bot_score;
        if (y > x) 
        {
            top = "ba";
            top_score = y;
            bot = "ab";
            bot_score = x;
        } 
        else 
        {
            top = "ab";
            top_score = x;
            bot = "ba";
            bot_score = y;
        }
        var stack = new List<char>();
        foreach (char ch in s) {
            if (ch == top[1] && stack.Count > 0 && stack[stack.Count - 1] == top[0])
            {
                res += top_score;
                stack.RemoveAt(stack.Count - 1);
            } 
            else
                stack.Add(ch);
        }
        // Removing bot substrings cause they give less or equal amount of scores
        var newStack = new List<char>();
        foreach (char ch in stack) {
            if (ch == bot[1] && newStack.Count > 0 && newStack[newStack.Count - 1] == bot[0]) {
                res += bot_score;
                newStack.RemoveAt(newStack.Count - 1);
            }
            else
                newStack.Add(ch);
        }
        return res;
    }
}