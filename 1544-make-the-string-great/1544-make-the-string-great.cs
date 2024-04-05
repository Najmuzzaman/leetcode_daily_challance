public class Solution {
    public string MakeGood(string s) {
        Stack<char> st = new Stack<char>();
        
        foreach (char c in s) {
            if (st.Count > 0 && Math.Abs(c - st.Peek()) == 32) {
                st.Pop();
            } else {
                st.Push(c);
            }
        }
        
        StringBuilder r = new StringBuilder();
        while (st.Count > 0) {
            r.Insert(0, st.Pop());
        }
        
        return r.ToString();
    }
}