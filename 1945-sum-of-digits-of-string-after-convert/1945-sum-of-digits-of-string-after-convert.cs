public class Solution {
    public int GetLucky(string s, int k) {
        int sum=0;
        foreach(char a in s)
        {
            int b=(a-'a')+1;
            while(b>0)
            {
                sum+=b%10;
                b/=10;
            }
        }
        for(int i=1;i<k;i++)
        {
            int a=sum;
            sum=0;
            while(a>0)
            {
                sum+=a%10;
                a/=10;
            }
        }
        return sum;
    }
}