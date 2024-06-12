public class Solution {
    public void SortColors(int[] nums) {
        int n= nums.Length;
        int[] ar=new int[301];
        for(int i=0;i<n;i++)
        {
            ar[nums[i]]++;
        }
        int j=0;
        for(int i=0;i<=300;i++)
        {
            while(ar[i]>0)
            {
                nums[j++]=i;
                ar[i]--;
            }
        }
    }
}