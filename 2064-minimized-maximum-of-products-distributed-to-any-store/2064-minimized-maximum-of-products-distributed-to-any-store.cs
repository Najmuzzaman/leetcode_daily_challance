public class Solution {
    private bool canDistribute(int[] quantities, int maxProducts, int n) 
    {
        int storesNeeded = 0;
        foreach (int quantity in quantities) 
        {
            storesNeeded += (int)Math.Ceiling((double)quantity / maxProducts);
            if (storesNeeded > n) return false;
        }
        return storesNeeded <= n;
    }
    public int MinimizedMaximum(int n, int[] quantities) 
    {
        int low = 1;
        int high = quantities.Max();;
        int answer = high;

        while (low <= high) 
        {
            int mid = low + (high - low) / 2;
            if (canDistribute(quantities, mid, n)) 
            {
                answer = mid;
                high = mid - 1;
            } else {
                low = mid + 1;
            }
        }

        return answer;
    }
}