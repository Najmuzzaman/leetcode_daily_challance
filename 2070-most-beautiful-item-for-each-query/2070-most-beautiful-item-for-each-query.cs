public class Solution {
    public int[] MaximumBeauty(int[][] items, int[] queries) {
        int n = items.Length;
        Dictionary<int, int> d = new Dictionary<int, int>();
        int MaxValue = 0;
        for(int i=0;i<n;i++)
        {
            int key=items[i][0];
            int value=items[i][1];
            if (d.ContainsKey(key))
                d[key]=Math.Max(d[key],value);
            else
                d[key]=value;
            MaxValue=Math.Max(MaxValue,value);
        }
        var comparer = Comparer<KeyValuePair<int, int>>.Create((a, b) => a.Key.CompareTo(b.Key));
        var updatedList = d.OrderBy(x => x.Key).ToList();
        n = queries.Length;
        int[] result = new int[n];
        int l=updatedList.Count;
        var sortedList = new List<KeyValuePair<int, int>>();
        MaxValue = 0;
        foreach(var a in updatedList)
        {
             MaxValue = Math.Max(MaxValue, a.Value);
             sortedList.Add(new KeyValuePair<int, int>(a.Key, MaxValue));
        }
        for (int i=0;i<n;i++)
        {
            int index = sortedList.BinarySearch(new KeyValuePair<int, int>(queries[i], 0), comparer);
            if (index<0)
            {
                index = ~index;
                index--;
            }
            if(index>=l || index==-1)
                result[i]= 0;
            else
                result[i]= sortedList[index].Value;
        }
        return result;
    }
}