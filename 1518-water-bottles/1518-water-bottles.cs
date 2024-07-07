public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int ans=numBottles;
        while(numBottles>=numExchange)
        {
            int ful=numBottles%numExchange;
            numBottles/=numExchange;
            ans+=numBottles;
            numBottles+=ful;            
        }
        return ans;
    }
}