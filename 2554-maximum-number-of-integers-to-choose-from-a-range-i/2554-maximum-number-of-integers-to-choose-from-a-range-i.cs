public class Solution {
    public int MaxCount(int[] banned, int n, int maxSum) {
        int m = banned.Length;
        int sum = 0;
        int count = 0;
        Array.Sort(banned);
        int j = 0;
        for(int i=1;i<=n;i++)
        {
            bool flag = true;
            while (j < m && banned[j] == i)
            {
                flag = false;
                j++;
            }
            if(flag)
            {
                sum += i;
                if(sum>maxSum)
                {
                    return count;
                }
                count++;
            }
        }
        return count;
    }
}