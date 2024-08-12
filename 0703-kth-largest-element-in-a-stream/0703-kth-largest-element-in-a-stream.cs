public class KthLargest {
    private PriorityQueue<int, int> topElements;
    private int limit;
    
    public KthLargest(int k, int[] nums) {
        limit = k;
        topElements = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => x.CompareTo(y)));

        foreach (int num in nums)
            Add(num);
    }
    
    public int Add(int val) {
         return AddElement(val);
    }
        
    private int AddElement(int newVal) 
    {
        if (topElements.Count < limit)
            topElements.Enqueue(newVal, newVal);
        else if (newVal > topElements.Peek()) 
        {
            topElements.Dequeue();
            topElements.Enqueue(newVal, newVal);
        }
        
        return topElements.Count == 0 ? 0 : topElements.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */