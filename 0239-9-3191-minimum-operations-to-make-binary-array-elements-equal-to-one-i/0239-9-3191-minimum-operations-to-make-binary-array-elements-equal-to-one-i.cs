public class Solution {
    public int MinOperations(int[] nums) {
        var count = nums.Sum();
        var rs = 0;
        int n = nums.Length;
        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] == 0)
            {
                rs++;
                for (int j = i; j < i + 3; j++)
                {
                    if (nums[j] == 1)
                    {
                        nums[j] = 0;
                        count--;
                    }
                    else
                    {
                        nums[j] = 1;
                        count++;
                    }
                }
            }
        }
        if (count != n) rs = -1;
        return rs;
    }
}