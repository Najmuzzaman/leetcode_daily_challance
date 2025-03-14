public class Solution {
    public int MaximumCandies(int[] candies, long k) {
        int ans = 0;
        int n=candies.Length;
        int start = 1;
        int end =  (int) 1e9;
        while(start <= end)
        {
            int mid = start + (end - start)/2;
            long count = 0;
            for(int i=0;i<n;i++) {
                if(candies[i] >= mid) {
                    count +=  candies[i] / mid;
                }
            }
            if(count < k) {
                end = mid -1;
            }
            else {
                ans = mid;
                start = mid+1;
            }
        }
        return ans;
    }
}