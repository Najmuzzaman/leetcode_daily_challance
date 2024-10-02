public class Solution {
    public int[] ArrayRankTransform(int[] arr) {
        int n= arr.Length;
        if(n==0) return arr;
        int[] ints = (int[]) arr.Clone();
        Dictionary<int,int> mp = new Dictionary<int,int>();
        Array.Sort(ints);
        int rank = 1;
        int num = ints[0];
        mp[num] = rank;
        for (int i=1;i<n;i++)
        {
            if (num != ints[i])
            {
                num= ints[i];
                rank++;
                mp[num] = rank;
            }
        }
        for (int i = 0; i < n; i++)
            ints[i] = mp[arr[i]];
        return ints;
    }
}