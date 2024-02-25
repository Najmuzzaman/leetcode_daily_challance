public class Solution {
    public bool CanTraverseAllPairs(int[] nums) {
        if (nums.Length == 1)
            return true;

        int n = nums.Length;
        int maxElement = nums.Max()+100;
        if (nums.Min() == 1)
            return false;
        
        int[] factorArray = FactorsCalculator(maxElement);

        int[] parent = new int[maxElement + 1];
        int[] rank = new int[maxElement + 1];
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = i;
            rank[i] = 1;
        }

        foreach (int num in nums)
        {
            int x = num;
            while (x > 1)
            {
                int p = factorArray[x];
                Union(parent, rank, p, num);
                while (x % p == 0)
                {
                    x = x / p;
                }
            }
        }

        int pp = Find(parent, nums[0]);
        for (int i = 1; i < nums.Length; i++)
        {
            if (Find(parent, nums[i]) != pp)
                return false;
        }

        return true;
    }
    
    private int[] FactorsCalculator(int n)
    {
        int[] dp = new int[n + 2];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = i;
        }
        for (int i = 2; i <= n; i++)
        {
            if (dp[i] == i)
            {
                for (int j = i * 2; j <= n; j += i)
                {
                    if (dp[j] == j)
                        dp[j] = i;
                }
            }
        }
        return dp;
    }
    private int Find(int[] parent, int a)
    {
        return parent[a] = parent[a] == a ? a : Find(parent, parent[a]);
    }

    private void Union(int[] parent, int[] rank, int a, int b)
    {
        a = Find(parent, a);
        b = Find(parent, b);
        if (a == b)
            return;
        if (rank[a] < rank[b])
        {
            int temp = a;
            a = b;
            b = temp;
        }
        parent[b] = a;
        rank[a] += rank[b];
    }
}