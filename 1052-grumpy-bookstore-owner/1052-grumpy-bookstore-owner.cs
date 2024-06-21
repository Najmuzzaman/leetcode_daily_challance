public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
        int n = customers.Length;
        int ans = 0;
        for (int i = 0; i < n; i++) 
             if (grumpy[i] == 0)
                ans += customers[i];
        
        int uns = 0;
        for (int i = 0; i < minutes; i++)
            if (grumpy[i] == 1)
                uns += customers[i];
        
        int mx = uns;
        for (int i = minutes; i < n; i++)
        {
            if (grumpy[i - minutes] == 1) 
                uns -= customers[i - minutes];
            if (grumpy[i] == 1) 
                uns += customers[i];
            mx = Math.Max(mx, uns);
        }
        return ans + mx;
    }
}