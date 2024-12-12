public class Solution {
    public long PickGifts(int[] gifts, int k) {                
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        foreach (int gift in gifts)
            maxHeap.Enqueue(gift, gift);
        
        for (int i = 0; i < k; i++)
        {
            int largest = maxHeap.Dequeue();
            int modified = (int)Math.Sqrt(largest);
            maxHeap.Enqueue(modified, modified);
        }
        long ans = 0;
        while (maxHeap.Count > 0)
            ans += maxHeap.Dequeue();

        return ans;
    }
}