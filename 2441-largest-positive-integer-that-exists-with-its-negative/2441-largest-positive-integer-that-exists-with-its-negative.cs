public class Solution {
    public int FindMaxK(int[] nums) {
        int[] pre=new int[2001];
        int n=nums.Length;
        int ans=-1;
        for(int i=0;i<n;i++)
        {
            int a=nums[i]+1000;
            pre[a]=1;
            
            int b =(-1*nums[i])+1000;
            if(pre[b]==1)
                ans=Math.Max(ans,Math.Max(a,b));
        }
        if(ans!=-1) 
            return ans-1000;
        else
            return -1;
    }
}