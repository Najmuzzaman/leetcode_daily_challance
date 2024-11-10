public class Solution {
    public int MinimumSubarrayLength(int[] nums, int k) 
    {
        int n = nums.Length;
        int[] bitCount = new int[32];
        int currentOR = 0;
        int j = 0;
        int minLength = int.MaxValue;
        
        for (int i = 0; i < n; i++) {
            currentOR |= nums[i];
            
            for (int bit = 0; bit < 32; bit++) {
                if ((nums[i] & (1 << bit)) != 0) {
                    bitCount[bit]++;
                }
            }
            
            while (j <= i && currentOR >= k) {
                minLength = Math.Min(minLength, i - j + 1);
                
                int updatedOR = 0;
                for (int bit = 0; bit < 32; bit++) {
                    if ((nums[j] & (1 << bit)) != 0) {
                        bitCount[bit]--;
                    }
                    if (bitCount[bit] > 0) {
                        updatedOR |= (1 << bit);
                    }
                }
                currentOR = updatedOR;
                j++;
            }
        }
        
        return minLength == int.MaxValue ? -1 : minLength;
    }
}