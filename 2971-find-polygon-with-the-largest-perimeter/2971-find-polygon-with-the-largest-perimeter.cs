public class Solution {
    public long LargestPerimeter(int[] nums) {
        Array.Sort(nums); // Sorting in non-decreasing order
        int n=nums.Length;
        long sum=nums[0] + nums[1];
        long para=0;
        for (int i = 2; i < n; i++) 
        {
            // Check if it forms a valid polygon
            if (sum > nums[i]) 
            {
                para=sum+nums[i];          
            }
            sum+=nums[i];
        }
        return para==0?-1:para;
    }
}