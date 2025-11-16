public class Solution {
    public int NumSub(string s) {
         int mod =1000000007;
        long count=0;
        long cc=0;
        foreach(char c in s)
        {
            if(c=='0') 
            {
                count+=cc*(cc+1)/2%mod;
                cc=0;continue;
            }
            cc++;

        }
        count+=(cc*(cc+1)/2)%mod;
        return (int)count;
    }
}