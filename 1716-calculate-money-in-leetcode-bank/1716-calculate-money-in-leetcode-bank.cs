public class Solution {
    public int TotalMoney(int n) {
        int weeks = n / 7;
        int days = n % 7;
            
        double full_weeks_sum = weeks * 28 + 7 * weeks * (weeks - 1) / 2;
        double remaining_sum = days * (weeks + 1) + days * (days - 1) / 2;
                
        return (int)(full_weeks_sum + remaining_sum);
    }
}