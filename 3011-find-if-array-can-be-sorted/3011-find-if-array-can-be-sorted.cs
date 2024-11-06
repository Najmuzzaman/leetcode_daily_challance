public class Solution {
    private int CountSetBits(int num)
    {
        int count = 0;
        while (num > 0)
        {
            count += num & 1;
            num >>= 1;
        }
        return count;
    }
    
    public bool CanSortArray(int[] nums) {
        int n=nums.Length;
        for(int i=0;i<n;i++)
            for(int j=0;j<n-1-i;j++)
        {
            if(nums[j]>nums[j+1])
            {
                if(CountSetBits(nums[j])==CountSetBits(nums[j+1]) )
                {
                    int a=nums[j];
                    nums[j]=nums[j+1];
                    nums[j+1]=a;
                }
                else
                    return false;
            }
        }
        
        return true;
    }
}