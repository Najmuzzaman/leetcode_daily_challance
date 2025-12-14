public class Solution {
    public int NumberOfWays(string corridor) {
        int x=1,y=0,z=0;
        int mod=1000000007;
        foreach(char c in corridor)
        {
            if(c=='S')
            {
                x=(x+z)%mod;
                z=y;
                y=x;
                x=0;
            }
            else
            {
                x=(x+z)%mod;
            }
        }
        return z;
    }
}