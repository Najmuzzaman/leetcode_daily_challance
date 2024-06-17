public class Solution {
    public bool JudgeSquareSum(int c) {
       for (int i = 2; i * i <= c; i++) {
            if (c % i == 0) {
                int cnt = 0;
                while (c % i == 0) {
                    cnt++;
                    c /= i;
                }
                if (i % 4 == 3 && cnt % 2 != 0) {
                    return false;
                }
            }
        }
        return c % 4 != 3; 
    }
}