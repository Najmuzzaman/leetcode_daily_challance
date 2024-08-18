public class Solution {
    
   
    public int NthUglyNumber(int n) 
    {
        HashSet<long> seen = new HashSet<long>();  // To keep track of generated ugly numbers
        PriorityQueue<long, long> heap = new PriorityQueue<long, long>();  // Min-heap to fetch the smallest ugly number

        long[] factors = new long[] { 2, 3, 5 };
        heap.Enqueue(1, 1);  // Start with the smallest ugly number
        seen.Add(1);
        
        long currentUgly = 1;

        for (int i = 1; i <= n; i++) 
        {
            currentUgly = heap.Dequeue();  // Get the smallest ugly number

            foreach (long factor in factors) 
            {
                long newUgly = currentUgly * factor;
                if (!seen.Contains(newUgly)) 
                {
                    seen.Add(newUgly);
                    heap.Enqueue(newUgly, newUgly);  // Add the new ugly number to the heap
                }
            }
        }

        return (int)currentUgly;
    }
}