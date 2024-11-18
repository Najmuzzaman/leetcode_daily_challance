public class Solution {
    int n;
    public int[] Decrypt(int[] code, int k) {
         n = code.Length;
         int[] ans = new int[n];
         for(int i=0;i<n;i++)
         {
             ans[i] = Sum(code, i, k);
         }
         return ans;
    }
    public int Sum(int[] code,int start, int k)
    {
        int sum = 0;
        if (k > 0)
        {
            for (int i = 0; i < k; i++)
                sum += code[(i + start + 1) % n];
        }
        else
        {
            k=Math.Abs(k);
            for (int i = 0; i < k; i++)
                sum += code[(n+ start - 1 - i) % n];
        }
        return sum;
    }
}