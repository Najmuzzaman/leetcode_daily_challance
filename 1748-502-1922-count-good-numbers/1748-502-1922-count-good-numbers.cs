public class Solution {
    public int CountGoodNumbers(long n) {
        long c=1+n%2*4;
        long m=20;
        long x=1000000007;
        for(;(n/=2)>0;m=m*m%x)
        {
            c=n%2>0?c*m%x:c;
        }
        return(int)c;
    }
}