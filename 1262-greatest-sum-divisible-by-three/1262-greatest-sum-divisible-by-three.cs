public class Solution {
    public int MaxSumDivThree(int[] nums) 
    {
        int[] dp = new int[3];

        dp[0] = 0;
        dp[1] = int.MinValue;
        dp[2] = int.MinValue;

        foreach(int num in nums) 
        {
            int newSum_0 = dp[0] + num;
            int newSum_1 = dp[1] + num;
            int newSum_2 = dp[2] + num;

            int nr_0 = newSum_0 % 3;
            int nr_1 = newSum_1 % 3;
            int nr_2 = newSum_2 % 3;

            // for each New reminder: 0, 1, 2
            for(int i =0; i < 3; i++) {
   
                if(nr_0 == i)
                    dp[i] = Math.Max(dp[i], newSum_0 );
                

                if(nr_1 == i )
                    dp[i] = Math.Max(dp[i], newSum_1 );
                

                if(nr_2 == i )
                    dp[i] = Math.Max(dp[i], newSum_2 );                
            }
        }
        return dp[0];
    }
}