public class Solution {
    public bool CanChange(string start, string target) {
        int n = start.Length;
        int i = 0, t = 0;

        while (i < n || t < n) 
        {
            while (i < n && start[i] == '_') 
                i++;
            
            
            while (t < n && target[t] == '_')
                t++;
            
            
            if (i == n || t == n)
                return i == n && t == n;
            

            if (start[i] != target[t] ||
                (start[i] == 'L' && i < t) ||
                (start[i] == 'R' && i > t))
                return false;

            i++;
            t++;
        }

        return true;
    }
}