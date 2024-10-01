public class Solution {
    public bool CanArrange(int[] arr, int k) {
        int n=arr.Length;
        int[] remainderCount = new int[k];

        for(int i=0;i<n;i++)
        {
            int rem = arr[i] % k;
            remainderCount[(rem+k)%k]++;
        }
        if (remainderCount[0] % 2 != 0) return false;
        if(k%2==0)
        {
            if(remainderCount[k/2] % 2 != 0) return false;
        }
        for(int i=1;i<k;i++)
        {
            if (remainderCount[i] != remainderCount[k-i])
                return false;
        }
        return true;
    }
}