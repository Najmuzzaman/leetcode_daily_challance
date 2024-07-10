public class Solution {
    public int MinOperations(string[] logs) {
        Stack<int> st=new Stack<int>();
        foreach(string log in logs)
        {
            if(log == "../")
            {
                if(st.Count() == 0) continue;
                st.Pop();
            }
            else if(log == "./") continue;
            else st.Push(1);            
        }
        return st.Count();
    }
}