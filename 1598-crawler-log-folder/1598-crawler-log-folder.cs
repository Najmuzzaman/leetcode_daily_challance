public class Solution {
    public int MinOperations(string[] logs) {
        int st=0;
        foreach(string log in logs)
        {
            if(log == "../")
            {
                if(st == 0) continue;
                st--;
            }
            else if(log == "./") continue;
            else st++;            
        }
        return st;
    }
}