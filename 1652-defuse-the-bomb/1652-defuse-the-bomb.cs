public class Solution {
    public int[] Decrypt(int[] code, int k) {
         int n = code.Length;
        int[] ans = new int[n];        
        
        if (k == 0) return ans;

        int sum = 0;
        int start = k > 0 ? 1 : n + k;
        int end = k > 0 ? k : n - 1;
        

        for (int i = start; i <= end; i++)
            sum += code[i % n];
        

        for (int i = 0; i < n; i++)
        {
            ans[i] = sum;
            sum -= code[start % n];
            start++;
            end++;
            sum += code[end % n];  
        }

        return ans;
    }
}