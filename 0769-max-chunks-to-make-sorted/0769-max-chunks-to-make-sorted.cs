public class Solution {
    public int MaxChunksToSorted(int[] arr) 
    {
        int maxV = 0;
        int count = 0;
        int n=arr.Length;
        for(int i=0; i<n; i++) 
        {
            maxV = Math.Max(maxV, arr[i]);
            if(maxV == i)
                count++;
        }
        return count;      

    }
}