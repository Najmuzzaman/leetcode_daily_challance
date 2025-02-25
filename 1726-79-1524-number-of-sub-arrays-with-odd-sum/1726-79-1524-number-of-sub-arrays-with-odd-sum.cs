public class Solution {
    public int NumOfSubarrays(int[] arr) 
    {
        int n=arr.Length;
        int sum=0;
        int ans=0;
        int e=1;
        int o=0;
        for(int i=0;i<n;i++)
        {
            int it=arr[i];
            sum+=it;
            if(sum%2==1)
            {
                o++;
                ans+=e;
            }
            else
            {
                e++;
                ans+=o;
            }
            ans=ans%1000000007;
        }
        return ans;
    }
}