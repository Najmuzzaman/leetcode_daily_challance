public class Solution {
    private Dictionary<string, List<int>> m = new Dictionary<string, List<int>>();
    public IList<int> DiffWaysToCompute(string expression) {
        if (m.ContainsKey(expression)) return m[expression];

        List<int> ans = new List<int>();        
        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];
            if (c == '+' || c == '-' || c == '*')
            {
                // Recursively solve left and right subproblems
                IList<int> left = DiffWaysToCompute(expression.Substring(0, i));
                IList<int> right = DiffWaysToCompute(expression.Substring(i + 1));

                // Combine results from left and right based on the operator
                foreach (int l in left)
                {
                    foreach (int r in right)
                    {
                        if (c == '+') ans.Add(l + r);
                        else if (c == '-') ans.Add(l - r);
                        else ans.Add(l * r);
                    }
                }
            }
        }
        // If the string is just a number, add it to the result list
        if (ans.Count == 0) ans.Add(int.Parse(expression));

        // Memoize the result for the current string
        m[expression] = ans;

        return ans;
    }
}