public class Solution {
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
        int n = heights.Length - 1;
        SortedList<int, List<int>> ladderUsed = new SortedList<int, List<int>>();
        for (int i = 0; i < n; ++i)
        {
            int diff = heights[i + 1] - heights[i];
            if (diff > 0)
            {
                if (!ladderUsed.ContainsKey(diff))
                {
                    ladderUsed[diff] = new List<int>();
                }
                ladderUsed[diff].Add(i);
                ladders--;
                if (ladders < 0)
                {
                    bricks -= ladderUsed.Keys[0];
                    ladderUsed[ladderUsed.Keys[0]].RemoveAt(0);
                    if(ladderUsed[ladderUsed.Keys[0]].Count==0)
                        ladderUsed.Remove(ladderUsed.Keys[0]);
                }
                if (bricks < 0) return i;
            }
        }
        return n;
    }
}