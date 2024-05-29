public class Solution {
    public int NumSteps(string s) {
        int n=s.Length;
        int a=0;
        int c=0;
        for(int i=n-1;i>0;i--)
        {
            if(s[i]=='1')
            {
                if(a == 1)
                {
                    a = 1;
                    c++;
                }
                else
                {
                    a = 1;
                    c += 2;
                }
            }
            else
            {
                if(a==1)
                {
                    a = 1;
                    c += 2;
                }
                else
                {
                    a = 0;
                    c++;
                }
            }
        }
        if(a==1) c++;
        return c;
    }
}