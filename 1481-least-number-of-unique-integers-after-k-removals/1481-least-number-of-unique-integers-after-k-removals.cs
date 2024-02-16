public class Solution {
    public int FindLeastNumOfUniqueInts(int[] arr, int k) {
         Dictionary<int,int> d= new Dictionary<int, int>();
         int n = arr.Length;
         for (int i = 0; i < n; i++)
         {
             if (d.ContainsKey(arr[i]))
                 d[arr[i]]++;
             else 
                 d[arr[i]]=1;
         }
         int ans = d.Count;
         var sortedDict = d.OrderBy(x => x.Value);
         foreach (var l in sortedDict)
         {
             n = l.Value;
             if (k >= n)
             {
                 k -= n;
                 ans--;
             }
             else
                 break;
         }
         return ans;
    }
}