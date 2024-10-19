public class Solution {
    public char FindKthBit(int n, int k) 
    {
        n--;
        string s = "0";
        while(n-->0)
        {
            char[] ch= s.ToCharArray();
            ch = Invert(ch);
            Array.Reverse(ch);
            s = s+"1" + new string(ch);
        }
        return s[k - 1];
    }
    private char[] Invert(char[] ch)
    {
        int n = ch.Length; 
        for(int i=0;i<n;i++)
        {
            if(ch[i] =='1')
                ch[i] = '0';
            else
                ch[i] = '1';
        }
        return ch;
    }
}