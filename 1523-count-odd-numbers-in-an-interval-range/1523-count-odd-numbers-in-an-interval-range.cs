public class Solution {
    public int CountOdds(int low, int high) {
        int a=low/2;
        int b=(high+1)/2;
        return b-a;
    }
}