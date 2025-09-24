public class Solution {
    StringBuilder number;
    Dictionary<long, int> visited;
    public string FractionToDecimal(int numerator, int denominator) {
        if(numerator==0) return "0";
    visited= new();
    number = new();

        if(numerator<0 ^ denominator <0) number.Append('-');

    long n = numerator;
    long  d= denominator;
    n = Math.Abs(n);
    d = Math.Abs(d);
    number.Append((n/d).ToString());

        if(n%d ==0) return number.ToString();

    number.Append('.');
    
    division(n%d,d);

    return number.ToString();
    }

    private void division(long numerator, long denominator){
        if(numerator ==0) return;
        if(visited.ContainsKey(numerator)){
           number.Insert(visited[numerator], '(');
           number.Append(')');
           return;
        }
        visited.Add(numerator, number.Length);
        numerator*=10;
        number.Append((numerator/denominator).ToString());
        division((numerator%denominator),denominator);
    }
}