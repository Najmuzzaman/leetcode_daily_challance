public class Solution {
    public int Tribonacci(int n) {
        long a=0;
        long b=0;
        long c=1;
        if(n==0) return 0;
        for(int i=1;i<n;i++)
        {
            long t=c;            
            c=a+b+c;
            a=b;
            b=t;
        }
        return (int)c;
    }
}