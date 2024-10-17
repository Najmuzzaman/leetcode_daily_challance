public class Solution {
    public int MaximumSwap(int num) {
         StringBuilder s = new StringBuilder(num.ToString());
         int n=s.Length;
         for(int i=0;i<n;i++)
         {
             int d1 = s[i]-'0';
             int d2 = d1;
             int ind = i;
             for (int j=n-1;j>=i+1;j--)
             {
                 if (d2 < (s[j] - '0'))
                 {
                     d2 = Math.Max(d2, s[j] - '0');
                     ind = j;
                 }                
             }
             if (d1 < d2)
             {
                 s[i] = d2.ToString()[0];
                 s[ind] = d1.ToString()[0];
                 break;
             }
         }
         num = Convert.ToInt32(s.ToString());
         return num; 
    }
}