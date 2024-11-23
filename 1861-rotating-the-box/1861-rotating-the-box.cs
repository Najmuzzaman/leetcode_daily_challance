public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        
        int n=box.Length;
        int m= box[0].Length;
        char[][] result=new char[m][];
        for(int i=0;i<n;i++)
        {
            for(int j=0;j < m;j++)
            {
                if(i==0)
                    result[j] = new char[n];
               
                result[j][i] = box[i][j];
            }
        }
        
        for (int i = 0; i < m; i++)
            Array.Reverse(result[i]);
    

        for (int j = 0; j < n; j++)
        {
            for (int i = m - 1; i >= 0; i--)
            {
                if (result[i][j] == '.')
                { 
                    int nextRowWithStone = -1;

                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (result[k][j] == '*')
                            break;
                        if (result[k][j] =='#')
                        {  
                            nextRowWithStone = k;
                            break;
                        }
                    }

                    if (nextRowWithStone != -1)
                    {
                        result[nextRowWithStone][j] = '.';
                        result[i][j] = '#';
                    }
                }
            }
        }
        return result;
    }
}