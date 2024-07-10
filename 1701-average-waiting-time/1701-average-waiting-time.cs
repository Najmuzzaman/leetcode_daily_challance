public class Solution {
    public double AverageWaitingTime(int[][] customers) {
        double sum = 0;
        int arrival = 0;
        int n = customers.Length;
        int finish = customers[0][0];
        for(int i=0; i < n; i++)
        {
            arrival = customers[i][0];
            if(finish < arrival)
                finish = arrival;
            
            finish = finish + customers[i][1];
            sum = sum + (finish - arrival);
        }
        return sum/n;
    }
}