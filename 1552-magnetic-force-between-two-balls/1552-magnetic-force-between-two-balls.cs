public class Solution {
    public int n;
    private bool canWePlace(int[] arr, int dist, int e)
    {
        int cnt=1;
        int last = arr[0];
        for(int i=0;i<n;i++)
        {
            if(arr[i]-last>=dist)
            {
                cnt++;
                last = arr[i];
            }
            if(cnt>=e)
                return true;
        }
        return false;
    }
    
    public int MaxDistance(int[] position, int m) 
    {
        Array.Sort(position);
        n=position.Length;
        int lo = 1;
        int hi = (position[n-1]-position[0])/(m-1);
        int ans = 1;
        while(lo<=hi)
        {
            int mid = lo+(hi-lo)/2;
            if(canWePlace(position, mid, m))
            {
                ans = mid;
                lo=mid+1;
            }
            else
                hi = mid-1;
        }
        return ans;
    }
}