public class Solution {
    public int MinDays(int[] bloomDay, int m, int k) {
        int st = 0, ed = 1000000000;
        int ans = -1;
        int n=bloomDay.Length;

        while (st <= ed) 
        {
            int mid = st + (ed - st) / 2;
            int con = 0, cnt = 0;
            for (int i = 0; i < n; i++)
                if (bloomDay[i] <= mid) 
                {
                    con++;
                    if (con >= k) 
                    {
                        cnt++;
                        con = 0;
                    }
                } 
                else 
                    con = 0;

            if (cnt >= m) 
            {
                ans = mid;
                ed = mid - 1;
            } 
            else
                st = mid + 1;
        }
        return ans;
    }
}