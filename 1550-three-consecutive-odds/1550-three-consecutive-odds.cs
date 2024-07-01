public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int n= arr.Length;
        int cnt=0;
        for(int i=0;i<n;i++)
        {
            if(arr[i]%2==1)
                cnt++;
            else
                cnt=0;
            if(cnt==3)
                return true;
        }
        return false;
    }
}