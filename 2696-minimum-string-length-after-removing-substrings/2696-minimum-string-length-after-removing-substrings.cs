public class Solution {
    public int MinLength(string s) 
    {
        Stack<char> stack = new Stack<char>();
        
        foreach (char c in s) 
        {
            bool flag=true;
            if (stack.Count > 0) 
            {
                char top = stack.Peek();
                if ((top == 'A' && c == 'B') || (top == 'C' && c == 'D'))
                {
                    stack.Pop();
                    flag=false;
                }
            }
            if(flag)
                stack.Push(c);
        }
        return stack.Count;
    }
}