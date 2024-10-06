public class Solution {
    public bool AreSentencesSimilar(string sentence1, string sentence2) {
        if(sentence1== sentence2) return true;
        string[] s1 = sentence1.Split(' ');
        string[] s2 = sentence2.Split(' ');
        int fs = 0;
        int fe = s1.Length - 1;
        int ss = 0;
        int se = s2.Length - 1;
        while (fs <= fe && ss <= se && s1[fs]==s2[ss])
        {
            fs++;
            ss++;
        }
        while (fs <= fe && ss <= se && s1[fe] == s2[se])
        {
            fe--;
            se--;
        }
        return fe < fs || se < ss;
    }
}