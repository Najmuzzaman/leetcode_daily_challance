public class Solution {
    public string CustomSortString(string order, string s) {
        Dictionary<char, int> orderMap = new Dictionary<char, int>();

        // Create a map to store the indices of characters in order
        for (int i = 0; i < order.Length; i++) {
            orderMap[order[i]] = i;
        }

        // Custom comparer function to sort characters based on orderMap
        Comparison<char> comparer = (char c1, char c2) => {
            int index1 = orderMap.ContainsKey(c1) ? orderMap[c1] : int.MaxValue;
            int index2 = orderMap.ContainsKey(c2) ? orderMap[c2] : int.MaxValue;
            return index1.CompareTo(index2);
        };

        // Sort the characters in s based on the custom comparer
        char[] sortedChars = s.ToCharArray();
        Array.Sort(sortedChars, comparer);

        // Convert sorted characters back to string
        return new string(sortedChars);
    }
}