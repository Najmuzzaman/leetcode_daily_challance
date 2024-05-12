public class Solution {
    public int[][] LargestLocal(int[][] grid)
    {
        int n = grid.Length;
        int[][] ans=new int[n - 2][];
        for(int i = 0; i < n -2; i++) 
        {
            ans[i ]=new int[n-2];
            for(int j = 0; j < n -2; j++)
            {
                int t = 0;
                for(int k = i ; k <= i + 2; k++)
                    for(int l = j ; l <= j + 2; l++) 
                        t = Math.Max(t, grid[k][l]);                
                ans[i][j] = t;
            }
        }

        return ans;
    } 
}