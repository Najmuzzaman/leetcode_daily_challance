public class Solution {
    public int[] SmallestRange(IList<IList<int>> nums) {
        int k = nums.Count;
        int[] indices = new int[k];
        int[] range = new int[2] { 0, int.MaxValue };
        while (true)
        {
            int curMin = int.MaxValue;
            int curMax = int.MinValue;
            int minList = 0;
            for (int i = 0; i < k; i++)
            {
                int cur = nums[i][indices[i]];
                if (cur < curMin)
                {
                    curMin = cur;
                    minList = i;
                }

                if (cur > curMax)
                    curMax = cur;
            }
            if (curMax - curMin < range[1] - range[0])
            {
                range[0] = curMin;
                range[1] = curMax;
            }
            if (++indices[minList] == nums[minList].Count) break;
        }
        return range;
    }
}