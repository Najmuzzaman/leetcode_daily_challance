public class Solution {
    public int FindTheLongestSubstring(string s) {
       Dictionary<int, int> maskToIndex = new Dictionary<int, int>();
        
        // Initialize the mask and result
        int mask = 0, maxLength = 0;
        
        // We start by assuming the mask at index -1 is 0 (no vowels seen yet)
        maskToIndex[0] = -1;
        
        // Iterate over the string
        for (int i = 0; i < s.Length; i++) {
            // Update the mask when we encounter a vowel
            switch (s[i]) {
                case 'a':
                    mask ^= (1 << 0); // Flip the bit for 'a'
                    break;
                case 'e':
                    mask ^= (1 << 1); // Flip the bit for 'e'
                    break;
                case 'i':
                    mask ^= (1 << 2); // Flip the bit for 'i'
                    break;
                case 'o':
                    mask ^= (1 << 3); // Flip the bit for 'o'
                    break;
                case 'u':
                    mask ^= (1 << 4); // Flip the bit for 'u'
                    break;
            }
            
            // If this mask has been seen before, update the max length
            if (maskToIndex.ContainsKey(mask)) {
                maxLength = Math.Max(maxLength, i - maskToIndex[mask]);
            } else {
                // Otherwise, record the first occurrence of this mask
                maskToIndex[mask] = i;
            }
        }
        
        return maxLength;  
    }
}