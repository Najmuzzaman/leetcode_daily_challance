public class Solution {
    public int LeastInterval(char[] tasks, int n) 
    {
        int[] fe = new int[26];
        foreach (char task in tasks) 
            fe[task - 'A']++;
        
        Array.Sort(fe);
        int feq = fe[25] - 1;
        int idle = feq * n;
        for (int i = 24; i >= 0; i--)
            idle -= Math.Min(feq, fe[i]);

        return idle < 0 ? tasks.Length : tasks.Length + idle;
    }
}