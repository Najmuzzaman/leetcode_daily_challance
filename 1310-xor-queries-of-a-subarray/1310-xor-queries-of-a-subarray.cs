public class Solution {
    public int[] XorQueries(int[] arr, int[][] queries) {
        int n = arr.Length;
        int[] prefixXor = new int[n + 1];
        int q = queries.Length;
        int[] result = new int[q];
        
        // Step 1: Compute prefix XOR
        for (int i = 0; i < n; i++) {
            prefixXor[i + 1] = prefixXor[i] ^ arr[i];
        }
        
        // Step 2: Answer each query in constant time
        for (int i = 0; i < q; i++) {
            int left = queries[i][0];
            int right = queries[i][1];
            result[i] = prefixXor[right + 1] ^ prefixXor[left];
        }
        
        return result;
    }
}