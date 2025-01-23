public class Solution {
    public int CountServers(int[][] grid) {
         int n = grid.Length; 
        int m = grid[0].Length;
        
        int[] row=new int[n];
        int[] col=new int[m];
        for(int i=0; i<n; i++)
        {
            for(int j=0; j<m; j++)
            {
                if(grid[i][j]==1)
                {
                    row[i]++; 
                    col[j]++;
                }
            }
        }
        
        int ans = 0;
        for(int i=0; i<n; i++)
        {
            for(int j=0; j<m; j++)
            {
                if(grid[i][j]==1 && (row[i]>1 || col[j]>1))
                    ans++;
            }
        }
        return ans;
    }
}