public class Solution {
    public string MaximumOddBinaryNumber(string s) {
        int one = 0;
        int n=s.Length;
        foreach (char c in s)
            if(c=='1') one++;
        one--;
        n--;
        StringBuilder result = new StringBuilder();
        result.Append('1', one);
        result.Append('0', n-one);
        result.Append('1');
        return result.ToString();
    }
}