public class Solution {
    public int LongestSubarray(int[] nums) {
        int max = 0;
        int count = 0;
        int precord = 1;

        for (int i=0; i<nums.Length; i++)
        {
            if (nums[i] < max)            
                count = 0;
            if (nums[i] == max) 
            {
                count++;
                if (count > precord) precord = count;
            }

            if (nums[i] > max) // new max
            {
                max = nums[i];
                count = 1;
                precord = 1;
            }
        }
        return precord;
    }
}