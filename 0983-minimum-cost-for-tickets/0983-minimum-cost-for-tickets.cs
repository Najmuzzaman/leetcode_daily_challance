public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        int n = days.Length;
        int[] dp=new int[n+1];
        dp[0] = 0;
        dp[1] = costs.Min();
        for (int i = 1; i < n; i++)
        {
            int win = 0;
            int kin = 0;
            for(int j=i;j>=0;j--)
            {
                if (days[i] - days[j] < 7)
                    win = j;
                if (days[i] - days[j] < 30)
                    kin = j;
                else
                    break;
            }
            int[] cost = new int[3];
            cost[0] = dp[i]+costs[0];
            cost[1] = dp[win]+costs[1];
            cost[2] = dp[kin] +costs[2];

            dp[i+1] = cost.Min();
        }
        return dp[n];
    }
}