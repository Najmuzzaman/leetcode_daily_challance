public class Solution {
    public string CountAndSay(int n) {
        if (n <= 0) return "";

        string result = "1";

        for (int i = 1; i < n; i++)
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;
            for (int j = 1; j < result.Length; j++)
            {
                if (result[j] == result[j - 1])
                {
                    count++;
                }
                else
                {
                    sb.Append(count);
                    sb.Append(result[j - 1]);
                    count = 1;
                }
            }

            // Append the last group
            sb.Append(count);
            sb.Append(result[result.Length - 1]);

            result = sb.ToString();
        }

        return result;
    }
}