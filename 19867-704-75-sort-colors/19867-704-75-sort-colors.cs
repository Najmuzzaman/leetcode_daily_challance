public class Solution {
    public void SortColors(int[] nums) {
        int n=nums.Length;
        int[] s=new int[3];
        for(int i=0;i<n;i++)
            s[nums[i]]++;
        int j=0;
        for(int i=0;i<3;i++)
        {
            while(s[i]>0)
            {
                nums[j++]=i;
                s[i]--;
            }
        }
    }
}