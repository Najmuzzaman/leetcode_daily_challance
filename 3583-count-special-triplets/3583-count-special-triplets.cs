public class Solution {
    public int SpecialTriplets(int[] nums) {
        int size = (int)Math.Pow(10,5)+1, mod = (int)Math.Pow(10, 9)+7, len = nums.Length;
        int[] leftFreq = new int[size], rightFreq = new int[size];
        leftFreq[nums[0]]++;
        long res = 0;

        for(int i = 1; i < len; i++)
        {
            int cur = nums[i];
            rightFreq[cur]++;
        }

        for(int i = 1; i < len-1; i++)
        {
            int mid = nums[i];
            rightFreq[mid]--;
            int doubleN = mid*2;
            
            if(doubleN <= size && leftFreq[doubleN] > 0 && rightFreq[doubleN] > 0)
            {
                res = (res + (long)leftFreq[doubleN]*rightFreq[doubleN])%mod;
            }

            leftFreq[mid]++;

        }

        return (int)res;
    }
}