public class Solution {
    public int MaxFrequencyElements(int[] nums) {
        int[] feq=new int[101];
        int n=nums.Length;
        int ma=0,mx=0;
        for(int i=0;i<n;i++)
        {
            feq[nums[i]]++;
            if(ma<feq[nums[i]])
                ma=feq[nums[i]];
            if(mx<nums[i])
                mx=nums[i];
        }
        int sum=0;
        for(int i=1;i<=mx;i++)
            if(ma==feq[i])
                sum+=ma;
        return sum;
    }
}