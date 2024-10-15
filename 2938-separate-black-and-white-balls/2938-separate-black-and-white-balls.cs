public class Solution {
    public long MinimumSteps(string s) {
        int n = s.Length;
        long blackCount = 0;
        long steps = 0;

        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1')
            {
                blackCount++;
            }
            else
            {
                steps += blackCount;
            }
        }

        return steps;
    }
}