public class Solution {
    public int MinOperations(int[] nums) {
         int n = nums.Length;
        int num1 = 0;
        int g = 0;
        foreach (int x in nums) {
            if (x == 1) {
                num1++;
            }
            g =  (int)BigInteger.GreatestCommonDivisor(g, x);
        }
        if (num1 > 0) {
            return n - num1;
        }
        if (g > 1) {
            return -1;
        }

        int minLen = n;
        for (int i = 0; i < n; i++) {
            int currentGcd = 0;
            for (int j = i; j < n; j++) {
                currentGcd = (int) BigInteger.GreatestCommonDivisor(currentGcd, nums[j]);
                if (currentGcd == 1) {
                    minLen = Math.Min(minLen, j - i + 1);
                    break;
                }
            }
        }
        return minLen + n - 2;
    }
}