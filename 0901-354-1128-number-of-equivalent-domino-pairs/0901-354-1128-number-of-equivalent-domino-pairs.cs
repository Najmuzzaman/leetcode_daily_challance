public class Solution {
    public int NumEquivDominoPairs(int[][] dominoes) {
         int[] counts = new int[100];
        int result = 0;
        
        foreach (int[] domino in dominoes) {
            int val1 = domino[0];
            int val2 = domino[1];
            
            int key = Math.Min(val1, val2) * 10 + Math.Max(val1, val2);
            
            result += counts[key];
            
            counts[key]++;
        }
        
        return result;
    }
}