public class Solution {
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) 
    {
        var robots = robot.OrderBy(x => x).ToArray();
        var factories = factory.OrderBy(x => x[0]).ToArray();
        
        int n = robots.Length, m = factories.Length;
        const long INF = 1L << 40;
        
		long[,,] dp = new long[100, 100, 101];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                for (int k = 0; k <= 100; k++) {
                    dp[i, j, k] = INF;
                }
            }
        }

        
        for (int i = 0; i < n; i++) 
		{
            for (int j = 0; j < m; j++) 
			{
                int xR = robots[i], xF = factories[j][0], capacity = factories[j][1];
                
                long otherFactory = (j == 0) ? INF : dp[i, j - 1, 0];

                dp[i, j, capacity] = otherFactory;
                
                // Assign the robot to the current factory if within capacity
                for (int k = capacity - 1; k >= 0; k--) {
                    long factoryJ = (i == 0) ? Math.Abs(xR - xF) : Math.Abs(xR - xF) + dp[i - 1, j, k + 1];
                    dp[i, j, k] = Math.Min(otherFactory, factoryJ);
                }
            }
        }
        return dp[n - 1, m - 1, 0];
    }
}