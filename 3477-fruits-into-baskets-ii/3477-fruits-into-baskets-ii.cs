public class Solution {
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
        int n=fruits.Length;
        int m=baskets.Length;
        for(int i=0;i<n;i++)
        {
            for(int j=0;j<m;j++)
            {
                if(baskets[j]>-1&&baskets[j]>=fruits[i])
                {
                    baskets[j]=-1;
                    fruits[i]=-1;
                    break;
                }
            }
        }
        int ans=0;
        foreach(var u in fruits)
            if(u!=-1)
                ans++;
        return ans;
    }
}