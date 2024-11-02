public class Solution {
    public bool IsCircularSentence(string sentence) {
        string[] strings = sentence.Split(' ');
        int n=strings.Length*2;
        char[] circle=new char[n];
        int i = 0;
        foreach (string s in strings)
        {
            circle[i++] = s[0];
            circle[i++] = s[s.Length-1];
        }
        if (circle[0] != circle[n-1])
            return false;

        for(i=2;i<n;i+=2)
        {
            if (circle[i-1] != circle[i])
                return false;
        }
        return true;
    }
}