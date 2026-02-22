public class Solution {
    public int BinaryGap(int n) 
    {
        int maxDistance = 0;
        int lastPosition = -1; 

        for (; n > 0; n &= (n - 1)) 
        {
            int currentPosition = BitOperations.TrailingZeroCount(n);            
            if (lastPosition != -1) {
                maxDistance = Math.Max(maxDistance, currentPosition - lastPosition);
            }            
            lastPosition = currentPosition;
        }        
        return maxDistance;
    }
}