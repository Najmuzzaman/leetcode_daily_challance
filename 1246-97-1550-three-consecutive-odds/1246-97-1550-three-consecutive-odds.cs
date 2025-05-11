public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int n=arr.Length;
        for(int i=0;i<n-2;i++)
        {
            if(arr[i]%2==1 && arr[i+1]%2==1 && arr[i+2]%2==1)
            {
                return true;
            }
        }
        return false;
    }
}