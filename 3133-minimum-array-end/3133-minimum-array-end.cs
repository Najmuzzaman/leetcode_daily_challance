public class Solution {
    public long MinEnd(int n, int x) {
         long result = x;

        while(n-->1) 
        {
            result = (result + 1) | x;
        }

        return result;
    }
}