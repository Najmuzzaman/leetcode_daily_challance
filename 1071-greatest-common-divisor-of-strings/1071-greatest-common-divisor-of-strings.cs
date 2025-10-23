public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        if (str1 + str2 != str2 + str1) return "";
        int length1 = str1.Length;
        int length2 = str2.Length;
        while(length2>0) {
            int temp = length2;
            length2 = length1 % length2;
            length1 = temp;
        }
        return str1.Substring(0, length1);
    }
}