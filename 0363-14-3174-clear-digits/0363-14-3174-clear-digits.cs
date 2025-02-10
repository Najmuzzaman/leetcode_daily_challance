public class Solution {
    public string ClearDigits(string s) {
        StringBuilder ans = new StringBuilder();
        foreach (char c in s)
        {
            if (char.IsDigit(c)) 
            {
                if (ans.Length > 0) 
                    ans.Remove(ans.Length - 1, 1);                 
            } 
            else
                ans.Append(c);            
        }
        return ans.ToString();
    }
}