public class Solution {
    public bool ParseBoolExpr(string expression) {
       while (expression.Length > 1) {
            int start = expression.LastIndexOfAny(new char[] { '!', '&', '|' });
            int end = expression.IndexOf(')', start);
            string subExpr = expression.Substring(start, end - start + 1);
            char result = EvaluateSubExpr(subExpr);
            expression = expression.Remove(start, end - start + 1).Insert(start, result.ToString());
        }
        return expression[0] == 't';
    }
    private char EvaluateSubExpr(string subExpr)
    {
        char op = subExpr[0];
        string values = subExpr.Substring(2, subExpr.Length - 3);
        if (op == '!') return values[0] == 't' ? 'f' : 't';
        if (op == '&') return values.Contains('f') ? 'f' : 't';
        if (op == '|') return values.Contains('t') ? 't' : 'f';
        return 'f';
    }
}