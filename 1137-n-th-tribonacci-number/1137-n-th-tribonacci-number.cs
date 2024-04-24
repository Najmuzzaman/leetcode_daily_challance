public class Solution {
    public int Tribonacci(int n) {
        int a=0;
        int b=0;
        int c=1;
        if(n==0) return 0;
        for(int i=1;i<n;i++)
        {
            int t=c;            
            c=a+b+c;
            a=b;
            b=t;
        }
        return c;
    }
}