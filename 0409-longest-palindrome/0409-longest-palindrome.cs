public class Solution {
    public int LongestPalindrome(string s) {
        HashSet<char> charSet = new HashSet<char>();
        int length = 0;
        
     
        foreach (char c in s) {
            if (charSet.Contains(c)) 
            {
                charSet.Remove(c);
                length += 2;
            } else 
            {
                charSet.Add(c);
            }
        }
        if (charSet.Count!=0) {
            length += 1;
        }
        return length;
    }
}