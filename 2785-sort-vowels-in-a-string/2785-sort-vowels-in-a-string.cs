public class Solution {
    public string SortVowels(string s) {
        char[] sChars = s.ToCharArray();
        List<char> vowels = new List<char>();
        foreach(char c in sChars){
            if(c == 'A' || c == 'E' ||c == 'I' ||c == 'O' ||c == 'U' ||c == 'a' ||c == 'e' ||c == 'i' ||c == 'o' ||c == 'u' ){
                vowels.Add(c);
            }
        }
        vowels.Sort();
        int k = 0;        
        for(int i =0;i<s.Length;i++){
            if(sChars[i] == 'A' || sChars[i] == 'E' ||sChars[i] == 'I' ||sChars[i] == 'O' ||sChars[i] == 'U' ||sChars[i] == 'a' ||sChars[i] == 'e' ||sChars[i] == 'i' ||sChars[i] == 'o' ||sChars[i] == 'u' ){
                sChars[i] = vowels[k];
                k++;
            }
        }
        return new string(sChars);
    }
}