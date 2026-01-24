public class Solution {
    public int MinPairSum(int[] nums) 
    {
        Array.Sort(nums);
        int ans=0;
        int i=0,j=nums.Length-1;

        while(i<j)
        {
            int cSum= nums[i]+nums[j];
            if(cSum>ans) 
                ans=cSum;
            i++;
            j--;
        }
        return ans;
    }
}