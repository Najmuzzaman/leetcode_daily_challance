public class Solution {
    public long dfs(string start, string finish, int limit, string s, int digit, int f, int st, long[,,] memo) 
    {
        if (digit == 0) 
            return 1;
        if (memo[digit, f, st] != -1) 
            return memo[digit, f, st];
        long tot = 0;
        if (digit <= s.Length) 
        {
            int question = s[s.Length - digit] - '0';
            int unable = 1;
            if ((finish[finish.Length - digit] - '0') > question)
                f = 1;
            else if ((finish[finish.Length - digit] - '0') < question && f == 0)
                unable = 0;
            if ((digit <= start.Length && (start[start.Length - digit] - '0') < question) || digit > start.Length)
                st = 1;
            else if (digit <= start.Length && (start[start.Length - digit] - '0') > question && st == 0)
                unable = 0;
            if (unable == 1)
                tot += dfs(start, finish, limit, s, digit - 1, f, st, memo);
        }
        else 
        {
            for (int i = 0; i <= limit; i++)
            {
                int tempF = f;
                int tempSt = st;
                if ((finish[finish.Length - digit] - '0') > i)
                    tempF = 1;
                else if ((finish[finish.Length - digit] - '0') < i && f == 0)
                    continue;
                if ((digit <= start.Length && (start[start.Length - digit] - '0') < i) || (digit > start.Length && i != 0))
                    tempSt = 1;
                else if (digit <= start.Length && (start[start.Length - digit] - '0') > i && st == 0)
                    continue; 
                tot += dfs(start, finish, limit, s, digit - 1, tempF, tempSt, memo);
            }
        }
        memo[digit, f, st] = tot;
        return tot;
    }
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
    {
        string first = start.ToString();
        string second = finish.ToString();
        int n = second.Length;

        long[,,] memo = new long[n + 1, 2, 2];

        for (int i = 0; i <= n; i++)
            for (int j = 0; j < 2; j++)
                for (int k = 0; k < 2; k++)
                    memo[i, j, k] = -1;
        return dfs(first, second, limit, s, n, 0, 0, memo);
    }
}