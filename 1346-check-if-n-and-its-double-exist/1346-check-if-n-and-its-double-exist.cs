public class Solution {
    public bool CheckIfExist(int[] arr) {
         Dictionary<int,bool> mp = new Dictionary<int,bool>();
         int n=arr.Length;
         for (int i=0;i<n;i++)
         {
             if (mp.ContainsKey(arr[i] * 2))
                 return true;
             if(arr[i]%2==0)
             {
                 if (mp.ContainsKey(arr[i] / 2))
                    return true;
             }
             mp[arr[i]] = true;
         }
         return false;
    }
}