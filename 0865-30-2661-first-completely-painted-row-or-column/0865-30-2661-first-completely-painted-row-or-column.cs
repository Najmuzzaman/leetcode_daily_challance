public class Solution {
    public int FirstCompleteIndex(int[] arr, int[][] mat) {
         int m = mat.Length;
        int n = mat[0].Length;
        int N = m * n;
        var numToIndex = new int[N + 1];
        Array.Fill(numToIndex, -1);
        for (int i = 0; i < N; i++)
            numToIndex[arr[i]] = i;

        var rowPainted = new int[m];
        var colPainted = new int[n];
        var rowPos = new int[N];
        var colPos = new int[N];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int num = mat[i][j];
                int indexInArr = numToIndex[num];
                rowPos[indexInArr] = i;
                colPos[indexInArr] = j;
            }
        }
        
        for (int i = 0; i < N; i++)
        {
            int num = arr[i];
            int rowIdx = rowPos[numToIndex[num]];
            int colIdx = colPos[numToIndex[num]];

            if (++rowPainted[rowIdx] == n || ++colPainted[colIdx] == m)
            {
                return i;
            }
        }

        return -1;
    }
}