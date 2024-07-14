using System.Text.RegularExpressions;

public class Solution {
    public string CountOfAtoms(string formula) {
        var stack = new Stack<Dictionary<string, int>>();
        stack.Push(new Dictionary<string, int>());
        int n = formula.Length;
        for (int i = 0; i < n; )
        {
            if (formula[i] == '(')
            {
                stack.Push(new Dictionary<string, int>());
                i++;
            }
            else if (formula[i] == ')')
            {
                var top = stack.Pop();
                i++;
                int start = i, multiplicity = 1;
                while (i < n && char.IsDigit(formula[i])) i++;
                if (i > start) multiplicity = int.Parse(formula.Substring(start, i - start));
                foreach (var p in top)
                {
                    if (!stack.Peek().ContainsKey(p.Key)) stack.Peek()[p.Key] = 0;
                    stack.Peek()[p.Key] += p.Value * multiplicity;
                }
            }
            else
            {
                int start = i;
                i++;
                while (i < n && char.IsLower(formula[i])) i++;
                string name = formula.Substring(start, i - start);
                start = i;
                while (i < n && char.IsDigit(formula[i])) i++;
                int multiplicity = i > start ? int.Parse(formula.Substring(start, i - start)) : 1;
                if (!stack.Peek().ContainsKey(name)) stack.Peek()[name] = 0;
                stack.Peek()[name] += multiplicity;
            }
        }
        var result = new StringBuilder();
        var count = stack.Pop();
        foreach (var name in new SortedDictionary<string, int>(count))
        {
            result.Append(name.Key);
            if (name.Value > 1) result.Append(name.Value);
        }
        return result.ToString();
    }
}