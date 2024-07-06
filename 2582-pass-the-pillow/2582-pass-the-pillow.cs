public class Solution {
    public int PassThePillow(int n, int time) {
       return n-Math.Abs(n-1-time%(2*(n-1)));
    }
}