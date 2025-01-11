public class Solution {
    public bool CanConstruct(string s, int k) {
        int n=s.Length;
        if(n<k) return false;
        if(n==k) return true;
        int c=0;
        for(int i=0;i<n;i++)
            c ^= 1<<(s[i]-'a');
        return BitOperations.PopCount((uint)c)<= k; 
    }
}