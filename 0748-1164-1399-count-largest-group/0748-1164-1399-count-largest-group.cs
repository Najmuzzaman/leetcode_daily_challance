public class Solution {
    public int CountLargestGroup(int n) {
        Dictionary<int, int> digitSumCounts = new Dictionary<int, int>();

        for (int i = 1; i <= n; i++) {
            int sum = DigitSum(i);
            if (!digitSumCounts.ContainsKey(sum)) {
                digitSumCounts[sum] = 0;
            }
            digitSumCounts[sum]++;
        }

        int maxCount = digitSumCounts.Values.Max();
        return digitSumCounts.Values.Count(v => v == maxCount);
    }

    private int DigitSum(int num) {
        int sum = 0;
        while (num > 0) {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}