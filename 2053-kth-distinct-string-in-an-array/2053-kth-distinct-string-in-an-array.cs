public class Solution {
    public string KthDistinct(string[] arr, int k) 
    {
        Dictionary<string, int> counter = new Dictionary<string, int>();
        foreach (string v in arr) 
        {
            if (counter.ContainsKey(v))
                counter[v]++;
            else 
                counter[v] = 1;            
        }
        foreach (string v in arr) 
        {
            if (counter[v] == 1) 
            {
                k--;
                if (k == 0) 
                    return v;
            }
        }
        return string.Empty;
    }
}