public class Solution {
    public string ReversePrefix(string word, char ch) {
        string s="";
        foreach(char c in word)
        {
            s+=c;
            if(c==ch)
            {
                s = new string(s.Reverse().ToArray());
                ch='.';
            }
        }
        return s;
    }
}