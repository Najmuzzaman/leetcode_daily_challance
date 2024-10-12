public class Solution {
    public int MinGroups(int[][] intervals) 
    {
        List<int> startEvents = new List<int>();
        List<int> endEvents = new List<int>();

        
        foreach (var interval in intervals)
        {
            startEvents.Add(interval[0]);
            endEvents.Add(interval[1] + 1);
        }
        
        startEvents.Sort();
        endEvents.Sort();
        
        int startPointer = 0, endPointer = 0;
        int currentGroups = 0, maxGroups = 0;

        while (startPointer < startEvents.Count) 
        {
            if (startEvents[startPointer] < endEvents[endPointer]) 
            {
                currentGroups++;
                maxGroups = Math.Max(maxGroups, currentGroups);
                startPointer++;
            }
            else 
            {
                currentGroups--;
                endPointer++;
            }
        }
        return maxGroups;
    }
}