public class Solution {
    public string CompressedString(string word) {
        int n=word.Length;
        char ch=word[0];
        int cnt=1;
        StringBuilder s=new StringBuilder();
        for(int i=1;i<n;i++)
        {
            if(ch==word[i])
            {
                cnt++;
                if(cnt>9)
                {
                    s.Append("9");
                    s.Append(ch);
                    cnt=1;
                }
            }
            else
            {
                s.Append(cnt.ToString());
                s.Append(ch);
                ch=word[i];
                cnt=1;
            }
        }
        s.Append(cnt.ToString());
        s.Append(ch);
        return s.ToString();
    }
}