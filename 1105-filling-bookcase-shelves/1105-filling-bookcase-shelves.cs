public class Solution {
    public int MinHeightShelves(int[][] books, int shelfWidth) {
       
        int n = books.Length;
        int[] dp=new int[n + 1];
        for(int i=0;i<n+1;i++)
            dp[i]= int.MaxValue ;
        dp[0] = 0;  // Base case: no books require 0 height
        
        for (int i = 1; i <= n; i++)
        {
            int t = 0;
            int m = 0;
            for (int j = i; j > 0; j--) 
            {
                t += books[j-1][0];
                if (t > shelfWidth)
                    break;
                
                m = Math.Max(m, books[j-1][1]);
                dp[i] = Math.Min(dp[i], dp[j-1] + m );
            }
        }
        
        return dp[n];
    }
}