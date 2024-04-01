public class Solution {
    public int LengthOfLastWord(string s) {
        string[] ss = s.Split(' ');
        int n=ss.Count();
        while (ss[n-1].Length==0)
            n--;
        return ss[n-1].Length;
    }
}