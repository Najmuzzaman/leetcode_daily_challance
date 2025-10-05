public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
         int m = heights.Length;
        int n = heights[0].Length;

        var results = new List<IList<int>>();

       bool[,] canReachPacific = new bool[m,n];
       bool[,] canReachAtlantic = new bool[m,n];

        for(int i = 0; i <  m; i++)
        {
            dfs(heights,canReachPacific,m,n,i,0);
            dfs(heights,canReachAtlantic,m,n,i,n-1);
        }

        for(int j = 0; j < n; j++)
        {
            dfs(heights,canReachPacific,m,n,0,j);
            dfs(heights,canReachAtlantic,m,n,m-1,j);
        }


        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(canReachPacific[i,j] && canReachAtlantic[i,j])
                {
                    results.Add(new List<int>(){i,j});
                }
            }
        }

        return results;
    }
     private void dfs(int[][] ocean, bool[,] canReach, int m, int n, int row, int col)
    {
        if(canReach[row,col]) return;

        canReach[row,col] = true;

        int[] directions = {-1, 0 , 1, 0, -1};

        for(int dir = 0; dir < 4; dir++)
        {
            int newRow = row + directions[dir];
            int newCol = col + directions[dir + 1];

            if(newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && ocean[newRow][newCol] >= ocean[row][col])
            {
                dfs(ocean,canReach,m,n,newRow,newCol);
            }
        }
    }
}