public class Solution {
    public int MinimumOneBitOperations(int n) {
        if(n==0) return 0;
        if(n==1) return 1;
        if(n<0) return n;
        int i=0;
        while((1<<i)<=n)
        {
            i++;
        }
        return ((1<<i)-1) - MinimumOneBitOperations(n-(1<<(i-1)));
    }
}