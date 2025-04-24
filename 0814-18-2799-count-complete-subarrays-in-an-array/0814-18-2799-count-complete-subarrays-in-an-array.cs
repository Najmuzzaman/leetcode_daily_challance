public class Solution {
    public int CountCompleteSubarrays(int[] nums) {
        int n = nums.Length;
        
        int[] freq = new int[2001];
        
        int neededDistinct = 0;
        for (int i = 0; i < n; i++) {
            if (freq[nums[i]] == 0) {
                neededDistinct++;
            }
            freq[nums[i]]++;
        }
        
        for (int i = 0; i < 2001; i++) {
            freq[i] = 0;
        }

        int have = 0;      // how many distinct we have in the current window
        int result = 0;
        int R = 0;         

        for (int L = 0; L < n; L++) {
            // Expand the right boundary while we do not yet have all distinct elements
            while (R < n && have < neededDistinct) {
                if (freq[nums[R]] == 0) {
                    have++;
                }
                freq[nums[R]]++;
                R++;
            }

            // If we have all distinct in [L..R-1], then every subarray [L..R-1..k] for k>=R-1
            // has all distinct => contributes (n - R + 1)
            if (have == neededDistinct) {
                result += (n - R + 1);
            }

            // Remove nums[L] from the window before moving L -> L+1
            freq[nums[L]]--;
            if (freq[nums[L]] == 0) {
                have--;
            }
        }

        return result;
    }
}