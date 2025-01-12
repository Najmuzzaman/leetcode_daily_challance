public class Solution {
    public bool CanBeValid(string s, string locked) {
        int n=s.Length;
         if (n % 2 != 0) 
            return false;
        int openCount = 0;
        for (int i = 0; i < n; i++) 
        {
            if (locked[i] == '0' || s[i] == '(') 
                openCount++;
            else 
                openCount--;
            if (openCount < 0) 
                return false;
        }

        openCount = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (locked[i] == '0' || s[i] == ')') 
                openCount++;
            else 
                openCount--;
            if (openCount < 0) 
                return false;
        }
        return true;
    }
}