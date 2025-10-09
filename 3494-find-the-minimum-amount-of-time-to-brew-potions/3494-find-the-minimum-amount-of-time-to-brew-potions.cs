public class Solution {
    public long MinTime(int[] skill, int[] mana) {
        int m = skill.Length;
        int n = mana.Length;
        var finishTime = new long[m];

        for(int j=0;j<n;j++)
        {
            finishTime[0] =  finishTime[0] + mana[j]*skill[0];
            for(int i=1;i<m;i++)
                finishTime[i] = Math.Max(finishTime[i-1],finishTime[i]) + mana[j]*skill[i];
            
            for(int i=m-1;i>0;i--)
                finishTime[i-1] = finishTime[i] -  mana[j]*skill[i];
            
        }
        return finishTime[m-1];
    }
}