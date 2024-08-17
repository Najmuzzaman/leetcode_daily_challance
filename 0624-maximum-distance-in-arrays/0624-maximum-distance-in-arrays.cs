public class Solution {
    public int MaxDistance(IList<IList<int>> arrays) 
    {
         int maxDistance = 0;
        
        int minValue = arrays[0][0];
        int maxValue = arrays[0][arrays[0].Count - 1];
        
        for (int i = 1; i < arrays.Count; i++) 
        {
            int currentMin = arrays[i][0];
            int currentMax = arrays[i][arrays[i].Count - 1];
            
            // Calculate the maximum distance using the current array's min and max
            maxDistance = Math.Max(maxDistance, Math.Abs(currentMax - minValue));
            maxDistance = Math.Max(maxDistance, Math.Abs(maxValue - currentMin));
            
            // Update min and max values for future comparisons
            minValue = Math.Min(minValue, currentMin);
            maxValue = Math.Max(maxValue, currentMax);
        }
        
        return maxDistance;
    }
}