public class Solution {
    public int MinIncrementForUnique(int[] nums) {
        Array.Sort(nums);
        int cnt = 0;
        int ans = 0;

        foreach(int num in nums)
        {
            cnt = Math.Max(cnt, num);
            ans += (cnt - num);
            cnt ++;
        }
        return ans;
    }
}