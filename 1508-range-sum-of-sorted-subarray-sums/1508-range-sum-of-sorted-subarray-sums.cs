public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

        for (int i = 0; i < n; i++)
        {
            int currItrSum = 0;
            for (int j = i; j < n; j++)
            {
                currItrSum += nums[j];
                pq.Enqueue(currItrSum, currItrSum);
            }
        }

        int total = right - left + 1;
        left--;
        while (left-- > 0)
            pq.Dequeue();

        int mod = 1000000007;
        int sum = 0;
        while (total-- > 0)
        {
            sum += pq.Dequeue();
            sum %= mod;
        }

        return sum;
    }
}