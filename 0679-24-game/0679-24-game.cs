public class Solution {
    private const double EPS = 0.00001;
    private const int TARGET = 24;

    public bool JudgePoint24(int[] cards) {
        var values = cards.Select(c => (double)c).ToList();
        return dfs(values);
    }

    private static bool dfs(List<double> values) 
    {
         int n = values.Count;
        if (n == 1) 
            return Math.Abs(values[0] - TARGET) < EPS;
        

        for (int i = 0; i < n; i++) 
        {
            for (int j = i + 1; j < n; j++) 
            {
                var next = new List<double>();
                for (int k = 0; k < n; k++)
                    if (k != i && k != j) 
                        next.Add(values[k]);
                

                foreach (var val in Generate(values[i], values[j])) 
                {
                    next.Add(val);
                    if (dfs(next)) return true;
                    next.RemoveAt(next.Count - 1); // backtrack
                }
            }
        }
        return false;
    }

    private static List<double> Generate(double a, double b) 
    {
        var results = new List<double>(6);

        // commutative
        results.Add(a + b);
        results.Add(a * b);

        // non-commutative
        results.Add(a - b);
        results.Add(b - a);

        if (Math.Abs(b) > EPS) results.Add(a / b);
        if (Math.Abs(a) > EPS) results.Add(b / a);

        return results;
    }
}