public class Solution {
    
    private const int MOD = 1000000007;
    private List<int[]> possList;
    public int ColorTheGrid(int m, int n) {
        possList = new List<int[]>();
        GeneratePoss(m, 0, 0, new int[m]);

        int size = possList.Count;
        int[,] dp = new int[n, size];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < size; j++)
                dp[i, j] = -1;

        int ans = 0;

        for (int i = 0; i < size; i++) {
            ans = (ans + F(dp, 1, i, n, size)) % MOD;
        }

        return ans;
    }
    private int F(int[,] dp, int i, int j, int n, int m) {
        if (i == n) {
            return 1;
        }

        if (dp[i, j] != -1) {
            return dp[i, j];
        }

        int ans = 0;

        for (int k = 0; k < m; k++) {
            if (Cond(k, j)) {
                ans = (ans + F(dp, i + 1, k, n, m)) % MOD;
            }
        }

        dp[i, j] = ans;
        return ans;
    }

    private bool Cond(int x, int y) {
        int[] a = possList[x];
        int[] b = possList[y];

        for (int i = 0; i < a.Length; i++) {
            if (a[i] == b[i]) {
                return false;
            }
        }
        return true;
    }

    private void GeneratePoss(int m, int prev, int idx, int[] nums) {
        if (idx == m) {
            possList.Add((int[])nums.Clone());
            return;
        }

        for (int i = 1; i <= 3; i++) {
            if (i != prev) {
                nums[idx] = i;
                GeneratePoss(m, i, idx + 1, nums);
                nums[idx] = 0; // Optional in C# as the next overwrite is guaranteed
            }
        }
    }
}