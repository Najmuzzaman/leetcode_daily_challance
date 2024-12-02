public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        string[] sen=sentence.Split(' ');
        int i = 1;
        foreach (string s in sen)
        {
            if(s.Length>=searchWord.Length)
            {
                if(s.Substring(0,searchWord.Length)==searchWord)
                    return i;
            }
            i++;
        }
        return -1;
    }
}