public class Solution {
    const int INF = 0x3fffffff;
    private string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
    
    public string NearestPalindromic(string n)
    {
        if (n.Length == 1)
        {
            long num = long.Parse(n);
            return (num - 1).ToString();
        }

        int hf = n.Length >> 1;
        string prefix = n.Substring(0, hf);
        long prefixNum = long.Parse(prefix);

        List<string> rslts = new List<string>
        {
            new string('9', n.Length - 1),
            "1" + new string('0', n.Length - 1) + "1"
        };

        if (n.Length % 2 == 1)
        {
            string suffix = Reverse(prefix);
            prefix += n[hf];
            rslts.Add(prefix + suffix);

            long num = long.Parse(prefix);
            string high = (num + 1).ToString();
            if (high.Length == prefix.Length)
            {
                suffix = Reverse(high.Substring(0, high.Length - 1));
                rslts.Add(high + suffix);
            }

            if (num > 1)
            {
                string low = (num - 1).ToString();
                if (low.Length == prefix.Length)
                {
                    suffix = Reverse(low.Substring(0, low.Length - 1));
                    rslts.Add(low + suffix);
                }
            }
        }
        else
        {
            string suffix = Reverse(prefix);
            long num = long.Parse(prefix);
            rslts.Add(prefix + suffix);

            string high = (num + 1).ToString();
            if (high.Length == prefix.Length)
            {
                suffix = Reverse(high);
                rslts.Add(high + suffix);
            }

            if (num > 1)
            {
                string low = (num - 1).ToString();
                if (low.Length == prefix.Length)
                {
                    suffix = Reverse(low);
                    rslts.Add(low + suffix);
                }
            }
        }

        long? ans = null;
        long minn = INF;
        long target = long.Parse(n);

        foreach (string rslt in rslts)
        {
            long num = long.Parse(rslt);
            long diff = Math.Abs(num - target);
            if (diff > 0 && (diff < minn || (diff == minn && (ans == null || num < ans))))
            {
                ans = num;
                minn = diff;
            }
        }

        return ans.ToString();
    }
}