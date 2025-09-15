public class Solution {
    public int CanBeTypedWords(string text, string brokenLetters) {
        var set = new HashSet<char>(brokenLetters);
        bool isBroken = false;
        int count = 0;
        string[] arr = text.Split(" ");        
        foreach (var s in arr)
        {
            isBroken = false;
            foreach (var c in s)
            {
                if (set.Contains(c)) isBroken = true;
            }
            if (!isBroken) count++;
        }
        return count;
    }
}