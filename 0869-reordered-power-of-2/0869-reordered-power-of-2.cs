public class Solution {
    public bool ReorderedPowerOf2(int n) {
        var count = Count(n);
        for(int i = 0;i<=31;i++)
            if(Enumerable.SequenceEqual(count, Count(1<<i)))            
                return true;    

        return false;
    }

    int[] Count(int n)
    {
        int[] count = new int[10];
        while(n>0)
        {
            count[n%10]++;
            n /= 10;
        }
        return count;
    }
}