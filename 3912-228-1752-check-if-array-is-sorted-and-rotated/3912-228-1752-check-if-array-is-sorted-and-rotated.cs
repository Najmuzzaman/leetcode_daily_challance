public class Solution {
    public bool Check(int[] nums) {
        int n = nums.Length;
        bool flag = false;
        for(int i=1;i<n;i++)
        {
            if(!flag)
            {
                if(nums[i]<nums[i-1])
                {
                    if(nums[i]>nums[0]) 
                        return false;
                    else
                        flag = true;
                }
            }
            else if (nums[i]<nums[i-1] || nums[i]>nums[0])
                    return false;
        }

        return true;
    }
}