public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) 
    {
        int n=arr.Length;
        int r=n-1;
        while(r>0 && arr[r] >= arr[r-1])
            r--;
        int ans=r;
        int l=0;
        while(l<r && (l==0 || arr[l-1]<=arr[l]))
        {
            while(r<n && arr[l]>arr[r])
                r++;
            ans=Math.Min(ans,r-l-1);
            l++;
        }
        return ans;
    } 
}