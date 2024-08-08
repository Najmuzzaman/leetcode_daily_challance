public class Solution {
    private static bool inside(int i, int j, int rows, int cols)
    {
        return i >= 0 && i < rows && j >= 0 && j < cols;
    }
    
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart) {
        int[][] ans=new int[rows*cols][];
        ans[0] = new int[] { rStart, cStart };
        int layer = Math.Max(Math.Max(rows - rStart, cols - cStart), Math.Max(rStart + 1, cStart + 1)) + 1;
        int i=rStart, j=cStart, k=1;
        for(int m=1; m<layer; m++)
        {
            int di=0, dj=1, step=2*m-1;// right
            for(int a=0; a<step; a++)
            {
                i+=di;
                j+=dj;
                if (inside(i,j, rows, cols)) 
                    ans[k++]=new int[] { i, j };
            }
            di=1;
            dj=0; //down
            for(int a=0; a<step; a++)
            {
                i+=di;
                j+=dj;
                if (inside(i,j, rows, cols)) 
                    ans[k++]=new int[] { i, j };
            }
            di=0;
            dj=-1;//left
            step++; //next
            for(int a=0; a<step; a++)
            {
                i+=di;
                j+=dj;
                if (inside(i,j, rows, cols)) 
                    ans[k++]=new int[] { i, j };
            }
            di=-1;
            dj=0; //up
            for(int a=0; a<step; a++)
            {
                i+=di;
                j+=dj;
                if (inside(i,j, rows, cols)) 
                    ans[k++]=new int[] { i, j };
            }
        }
        return ans;
    }
}