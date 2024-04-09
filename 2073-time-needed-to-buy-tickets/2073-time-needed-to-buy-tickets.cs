public class Solution {
    public int TimeRequiredToBuy(int[] tickets, int k) {
        int total = 0;
        int n=tickets.Length;

        for (int i = 0; i < n; i++) 
        {
            if (i <= k) 
            {
                total += Math.Min(tickets[i], tickets[k]);
            }
            else 
            {
                total += Math.Min(tickets[i], tickets[k] - 1);
            }
        }

        return total;
    }
}