using System.Text.RegularExpressions;

public class Solution {
    private int gcd(int a, int b)
    {
        if (b == 0)
            return a;
        return gcd(b, a % b);
    }
    
    public string FractionAddition(string expression) {
        var matches = Regex.Matches(expression, @"[+-]?\d+");
        int[] nums = new int[matches.Count];
        
        for (int i = 0; i < matches.Count; i++)
        {
            nums[i] = int.Parse(matches[i].Value);
        }

        int numerator = 0;
        int denominator = 1;

        // Iterate through the list in pairs (numerator/denominator)
        for (int i = 0; i < nums.Length; i += 2)
        {
            int num = nums[i];
            int den = nums[i + 1];

            numerator = numerator * den + num * denominator;
            denominator *= den;
        }

        // Calculate the greatest common divisor (GCD)
        int commonDivisor = gcd(numerator, denominator);

        // Simplify the fraction
        numerator /= commonDivisor;
        denominator /= commonDivisor;
        
        if(denominator<0)
        {
            denominator*=-1;
            numerator*=-1;
        }

        return $"{numerator}/{denominator}";
    }
}