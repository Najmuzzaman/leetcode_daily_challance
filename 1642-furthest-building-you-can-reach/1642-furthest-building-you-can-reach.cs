public class Solution {
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
        int n = heights.Length - 1;
        SortedList<int, List<int>> ladderUsed = new SortedList<int, List<int>>();
        int totalElements=0;
        for (int i = 0; i < n; ++i)
        {
            int diff = heights[i + 1] - heights[i];
            if (diff > 0)
            {
                if (ladderUsed.ContainsKey(diff))
                {
                    ladderUsed[diff].Add(i);
                }
                else
                {
                    ladderUsed[diff] = new List<int>();
                    ladderUsed[diff].Add(i);
                }
                totalElements++;
                if (totalElements > ladders)
                {
                    bricks -= ladderUsed.Keys[0];
                    ladderUsed[ladderUsed.Keys[0]].RemoveAt(0);
                    if(ladderUsed[ladderUsed.Keys[0]].Count==0)
                        ladderUsed.Remove(ladderUsed.Keys[0]);
                    totalElements--;
                }
                if (bricks < 0) return i;
            }
        }
        return n;
    }
}