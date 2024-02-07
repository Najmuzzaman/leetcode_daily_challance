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
        // Create a StringBuilder to efficiently build the result string
        StringBuilder result = new StringBuilder();

        // Iterate over the dictionary in descending order of frequency
        foreach (var kvp in mp.OrderByDescending(x => x.Value)) {
            // Append the character kvp.Key to the result string kvp.Value times
            result.Append(kvp.Key, kvp.Value);
        }

        return result.ToString();
    }
}