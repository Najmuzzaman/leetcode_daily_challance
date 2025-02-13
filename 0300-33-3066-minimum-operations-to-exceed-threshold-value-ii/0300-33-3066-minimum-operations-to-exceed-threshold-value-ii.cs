public class Solution {
    public int MinOperations(int[] nums, int k) {
        int opCount = 0;
        PriorityQueue<long, long> pq = new PriorityQueue<long, long>();

        foreach (int num in nums) {
            pq.Enqueue(num, num); // Min-heap
        }

        while (pq.Peek() < k) {
            if (pq.Count < 2) {
                return -1;
            }

            long first = pq.Dequeue();
            long second = pq.Dequeue();
            long result = first * 2 + second;

            pq.Enqueue(result, result);
            opCount++;
        }

        return opCount;
    }
}