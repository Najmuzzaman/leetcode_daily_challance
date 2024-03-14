public class Solution {
    public int NumSubarraysWithSum(int[] nums, int goal) {
        int result = 0;
        int i = 0, sum = 0, cnt = 0;
        int n=nums.Length;
        for (int j = 0; j < n; j++) 
        {
            sum += nums[j];
            if (nums[j] == 1) 
                cnt = 0;

            while ((i <= j) && (sum >= goal)) {
                if (sum == goal) cnt++;
                sum -= nums[i++];
            }
            result += cnt;
        }
        return result;
    }
}