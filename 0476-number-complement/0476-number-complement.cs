public class Solution {
    public int FindComplement(int num) {
        int a=num;
        int ans=1;
        while(a!=1)
        {
            ans*=2;
            ans++;
            a/=2;
        }
        return ans-num;
    }
}