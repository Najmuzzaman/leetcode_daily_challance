public class Solution {
    public string MakeLargestSpecial(string s) {
         List<string> specials = new List<string>();
        int count = 0;
        int start = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
                count++;
            else
                count--;
            
            if (count == 0)
            {
                string inner = s.Substring(start + 1, i - start - 1);
                string processed = MakeLargestSpecial(inner);

                specials.Add("1" + processed + "0");

                start = i + 1;
            }
        }

        specials.Sort((a, b) => string.Compare(b, a, StringComparison.Ordinal));

        StringBuilder result = new StringBuilder();
        foreach (var special in specials)
        {
            result.Append(special);
        }

        return result.ToString();
    }
}