public class Solution {
    public int MaxBottlesDrunk(int numBottles, int numExchange) => numBottles >= numExchange
        ? numExchange + MaxBottlesDrunk(numBottles - numExchange + 1, numExchange + 1)
        : numBottles;
}