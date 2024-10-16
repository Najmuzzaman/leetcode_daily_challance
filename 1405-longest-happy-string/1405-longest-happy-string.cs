public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        int aa = 0, bb = 0, cc = 0;
        string ans = "";
        int total = a + b + c;
        for (int i = 0; i < total; i++) {
            if ((a >= b && a >= c && aa != 2) || (a > 0 && (bb == 2 || cc == 2)))
            {
                ans += 'a';
                a--;
                aa++;
                bb = 0;
                cc = 0;
            }
            else if ((b >= a && b >= c && bb != 2) || (b > 0 && (cc == 2 || aa == 2)))
            {
                ans += 'b';
                b--;
                bb++;
                aa = 0;
                cc = 0;
            }
            else if ((c >= a && c >= b && cc != 2) || (c > 0 && (aa == 2 || bb == 2))) 
            {
                ans += 'c';
                c--;
                cc++;
                aa = 0;
                bb = 0;
            }
        }
        return ans; 
    }
}