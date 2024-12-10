public class Solution {
    public int MaximumLength(string s) {
        Dictionary <string, int> count=new Dictionary<string,int>();
        int n=s.Length;
        for (int start = 0; start < n; start++) {
            string currString="";
            for (int end = start; end < n; end++) {                
                if (currString =="" || currString[currString.Length-1] == s[end]) {
                    currString += s[end];
                    if (count.ContainsKey(currString)) {
                        count[currString]++;
                    } else {
                        count[currString] = 1;
                    }
                } else {
                    break;
                }
            }
        }
        int ans = 0;
        foreach (var p in count)
        {
            string str = p.Key;
            if (p.Value >= 3 && str.Length > ans)
            {
                ans = str.Length;
            }
        }
        return ans == 0 ? -1 : ans;
        
        
    }
}