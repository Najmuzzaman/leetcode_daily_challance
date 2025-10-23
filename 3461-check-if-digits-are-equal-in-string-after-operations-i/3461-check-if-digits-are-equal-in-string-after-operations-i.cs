public class Solution {
    public bool HasSameDigits(string s) {
         char[] arr = s.ToCharArray();
        int len = arr.Length;
        while (len > 2) {
            for (int i = 0; i < len - 1; i++) {
                arr[i] = (char)(((arr[i]-'0' + arr[i+1]-'0') % 10) + '0');
            }
            len--;
        }
        return arr[0] == arr[1];
    }
}