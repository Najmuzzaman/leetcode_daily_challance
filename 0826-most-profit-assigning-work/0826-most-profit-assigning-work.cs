public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) 
    {
        int ma = 0;
        int n =  difficulty.Length;
        foreach (int d in difficulty)
            ma = Math.Max(ma, d);
        int[] maP = new int[ma + 1];
        for (int i = 0; i < n; i++)
            maP[difficulty[i]] = Math.Max(maP[difficulty[i]], profit[i]);
        for (int i = 1; i <= ma; i++) 
            maP[i] = Math.Max(maP[i], maP[i - 1]);
        int ans = 0;
        foreach (int ability in worker) 
        {
            if (ability > ma) 
                ans += maP[ma];
            else 
                ans += maP[ability];
        }
        return ans;
    }
}