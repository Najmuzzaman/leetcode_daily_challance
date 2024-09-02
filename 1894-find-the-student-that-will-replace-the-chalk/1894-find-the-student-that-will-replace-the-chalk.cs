public class Solution {
    public int ChalkReplacer(int[] chalk, int k) 
    {
        long totalChalk = 0;
        foreach (int c in chalk)
            totalChalk += c;
        

        // Step 2: Reduce k modulo totalChalk
        k = (int)(k % totalChalk);

        // Step 3: Find the student who will replace the chalk
        for (int i = 0; i < chalk.Length; i++) 
        {
            if (k < chalk[i])
                return i;
            k -= chalk[i];
        }

        return -1;
    }
}