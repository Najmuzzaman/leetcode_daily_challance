public class Solution {
    public int SpecialArray(int[] nums) 
    {
        Array.Sort(nums);
        int l = 1, r = 100;
        while (l <= r)
        {
            int mid = (l + r) / 2;
            int x = 0;
            for (int i = 0; i < nums.Length; ++i)
                x += (nums[i] >= mid) ? 1 : 0;
            if (x == mid)
                return x;
            if (x > mid)
                l = mid + 1;
            else
                r = mid - 1;
        }
        return -1;
    }
}