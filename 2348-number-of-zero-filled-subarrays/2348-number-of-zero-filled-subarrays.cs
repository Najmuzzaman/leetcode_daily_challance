public class Solution {
    public long ZeroFilledSubarray(int[] nums) {
        long ans = 0;
        long n = 0;
        foreach (var item in nums)
        {
            if (item == 0)
                n++;
            else
            {
                answer += n * (n + 1) / 2;
                count = 0;
            }
        }
        ans += n * (n + 1) / 2;
        return ans;
    }
}