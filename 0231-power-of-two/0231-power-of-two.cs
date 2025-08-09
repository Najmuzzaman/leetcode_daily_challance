public class Solution {
    public bool IsPowerOfTwo(int n) {
        while(n>0)
        {
            if(n==1)
                return true;
            if(n%2==0)
                n/=2;
            else
                return false;
        }
        return false;
    }
}