public class Solution {
    public int MinKBitFlips(int[] nums, int k) {
        int n = nums.Length;
        int flipped = 0;
        int ans = 0;
        int[] isFlipped=new int[n];

        for (int i = 0; i < n; ++i) 
        {
            if (i >= k)
                flipped ^= isFlipped[i - k];
            
            if (flipped == nums[i]) 
            {
                if (i + k > n) 
                    return -1;
                isFlipped[i] = 1;
                flipped ^= 1;
                ans++;
            }
        }
        return ans;
    }
}