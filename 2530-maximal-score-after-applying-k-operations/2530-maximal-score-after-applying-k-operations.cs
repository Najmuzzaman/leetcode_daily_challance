public class Solution {
    public long MaxKelements(int[] nums, int k) {
         PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        
        foreach (var num in nums) {
            maxHeap.Enqueue(num, num);
        }
        
        long score = 0; 
        
        for (int i = 0; i < k; i++) {
            int currentMax = maxHeap.Dequeue();
            score += currentMax; 
            
            int newValue = (int)Math.Ceiling(currentMax / 3.0);
            
            maxHeap.Enqueue(newValue, newValue);
        }
        
        return score;
    }
}