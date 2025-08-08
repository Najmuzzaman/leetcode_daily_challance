public class Solution {
    public double SoupServings(int n) {
         n = (int)Math.Ceiling(n / 25.0);           
        if(n > 200) return 1.0;
        Dictionary<(double, double),double> memo = new();
        return dfs(n, n,memo);
    }
        
    double dfs(double a, double b,Dictionary<(double, double),double> memo) {
        if (memo.ContainsKey((a, b))) return memo[(a,b)];
        if (a <= 0 && b <= 0) return 0.5;
        if (a <= 0) return 1.0;
        if (b <= 0) return 0.0;

        double op1 = dfs(a -4, b,memo);
        double op2 = dfs(a - 3, b -1,memo);
        double op3 = dfs(a - 2, b - 2,memo);
        double op4 = dfs(a -1, b -3,memo);
        double ans = 0.25 * ( op1 +  op2 + op3 + op4);
        memo[(a, b)] = ans;
        return ans;
    }
}