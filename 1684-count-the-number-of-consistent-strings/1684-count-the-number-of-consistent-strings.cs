public class Solution {
    public int CountConsistentStrings(string allowed, string[] words) {
         HashSet<char> allowedSet = new HashSet<char>(allowed);
        
        int consistentCount = 0;
        
        // Iterate through each word in the words array
        foreach (string word in words) {
            bool isConsistent = true;
            
            // Check if each character in the word is in the allowed set
            foreach (char c in word) {
                if (!allowedSet.Contains(c)) {
                    isConsistent = false;
                    break;
                }
            }
            
            // If the word is consistent, increment the counter
            if (isConsistent) {
                consistentCount++;
            }
        }
        
        return consistentCount;
    }
}