public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        StringBuilder sb = new StringBuilder();
        int i = 0;
        int l = 0;
        int n = spaces.Length;
        foreach(char c in s)
        {
            if(i<n)
            {
                if (spaces[i]==l)
                {
                    sb.Append(" ");
                    i++;
                }
            }
            sb.Append(c);
            l++;
        }
        return sb.ToString();
    }
}