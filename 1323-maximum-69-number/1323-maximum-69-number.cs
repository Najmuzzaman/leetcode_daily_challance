public class Solution {
    public int Maximum69Number (int num) {
        var firstin = first(num);
        if (firstin >= 0) num += 3 * (int)Math.Pow(10, firstin);
        return num;
    }
    private int first(int num)
    {
        var ans = -1;
        var curr = 0;
        while (num > 0)
        {
            var digit = num % 10;
            if (digit == 6) ans = curr;
            num /= 10;
            curr++;
        }
        return ans;
    }
}