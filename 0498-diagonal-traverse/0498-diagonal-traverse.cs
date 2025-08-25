public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        List<int> ans = new List<int>();
        var (n, m) = (mat.Length, mat[0].Length);
        Dictionary<int, LinkedList<int>> map = new Dictionary<int, LinkedList<int>>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++) 
            {
                int key = i + j;
                if (!map.ContainsKey(key)) 
                    map[key] = new LinkedList<int>();
                

                if (key % 2 is 0) 
                    map[key].AddFirst(mat[i][j]);
                else 
                    map[key].AddLast(mat[i][j]);
            }   
        }

        foreach (var (k, v) in map) 
            ans.AddRange(v);
        

        return ans.ToArray();
    }
}