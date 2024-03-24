public class Solution {
    public int FindDuplicate(int[] nums) {
        int[] a=new int[100009];
        int n=nums.Length;
        for(int i=0;i<n;i++)
        {
            a[nums[i]]++;
            if(a[nums[i]]>1) return nums[i];
        }
        return 0;
    }
}