public class Solution {
    public int LenLongestFibSubseq(int[] arr) {
         Dictionary<int, int> indexMap = new Dictionary<int, int>();
        Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
        int res = 0;

        for (int i = 0; i < arr.Length; i++)
            indexMap[arr[i]] = i;
        

        for (int j = 1; j < arr.Length; j++) 
        {
            for (int i = 0; i < j; i++) 
            {
                int prev = arr[j] - arr[i];
                if (indexMap.ContainsKey(prev) && indexMap[prev] < i) 
                {
                    int k = indexMap[prev];
                    dp[(i, j)] = dp.ContainsKey((k, i)) ? dp[(k, i)] + 1 : 2;
                    res = Math.Max(res, dp[(i, j)]);
                }
            }
        }        
        return res > 0 ? res + 1 : 0;
    }
}