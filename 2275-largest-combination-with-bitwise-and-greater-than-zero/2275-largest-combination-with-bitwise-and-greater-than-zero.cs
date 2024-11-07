public class Solution {
    public int LargestCombination(int[] candidates) 
    {
        int maxCombinationSize = 0;
        
        for (int bit = 0; bit < 24; bit++) 
        {
            int count = 0;
            foreach (int num in candidates)
                if ((num & (1 << bit)) != 0)
                    count++;
            maxCombinationSize = Math.Max(maxCombinationSize, count);
        }        
        return maxCombinationSize;
    }
}