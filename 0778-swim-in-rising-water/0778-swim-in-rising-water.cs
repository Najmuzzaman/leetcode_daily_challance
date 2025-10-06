public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        int[,] visited = new int[n,n];
        PriorityQueue<(int x,int y),int> qu = new();
        qu.Enqueue((0,0),0);
        visited[0,0]=1;
        int maxDis = int.MinValue;
        int[] dX = {-1,1,0,0};
        int[] dY = {0,0,-1,1};
        
        while(qu.Count>0)
        {
            var cur = qu.Dequeue();
            maxDis = Math.Max(maxDis,grid[cur.x][cur.y]);
            
            if(cur.x==n-1 && cur.y==n-1)
                return maxDis;
            
            for(int i=0;i<4;i++)
            {
                int a = cur.x + dX[i];
                int b = cur.y + dY[i];
                
                if(a<0 || a>=n || b<0 || b>=n || visited[a,b]==1)
                    continue;
                
                visited[a,b] = 1;
                qu.Enqueue((a,b),grid[a][b]);
            }
            
        }
        
        return maxDis;
    }
}