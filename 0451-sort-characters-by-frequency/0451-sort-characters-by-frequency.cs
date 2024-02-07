public class Solution {
    public string FrequencySort(string s) {
        Dictionary<char,int> mp = new Dictionary<char,int>();
        foreach (char c in s)
        {
            if(mp.ContainsKey(c))
            {
                mp[c]++;
            }
            else
            {
                mp[c] = 1;
            }
        }
        var sortedList = mp.ToList();
        sortedList.Sort((x, y) => y.Value.CompareTo(x.Value));        
        string a = "";
        foreach(var kvp in sortedList)
        {
            for(int i=0;i<kvp.Value;i++)
            {
                a+= kvp.Key;
            }
        }
        return a;
    }
}