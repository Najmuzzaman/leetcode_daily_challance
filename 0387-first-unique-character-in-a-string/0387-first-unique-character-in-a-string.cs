public class Solution {
    public int FirstUniqChar(string s) {
        int[] ind = new int[27];
        foreach (char c in s)
        {
            ind[c - 'a']++;
        }
        int i = 0;
        foreach (char c in s)
        {
            if (ind[c - 'a'] == 1)
                return i;
            i++;
        }
        return -1;
    }
}