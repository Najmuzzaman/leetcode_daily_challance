public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions); 
        int n = spells.Length;
        int m = potions.Length;
        int[] result = new int[n];
        
        for (int i = 0; i < n; i++) {
            long spellStrength = spells[i];
            
            long required = (success + spellStrength - 1) / spellStrength; 
            
            int index = BinarySearch(potions, required);
            
            result[i] = m - index;
        }
        
        return result;
    }
    private int BinarySearch(int[] potions, long required) {
        int left = 0, right = potions.Length - 1;
        
        while (left <= right) {
            int mid = left + (right - left) / 2;
            
            if (potions[mid] < required)
                left = mid + 1;
            else
                right = mid - 1;
        }
        
        return left; 
    }
}