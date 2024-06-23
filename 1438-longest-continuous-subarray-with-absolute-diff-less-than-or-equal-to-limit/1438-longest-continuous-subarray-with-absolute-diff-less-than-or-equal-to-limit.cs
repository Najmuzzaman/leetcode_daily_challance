public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        if (nums == null || nums.Length == 0)
            return 0;

        // Deques to store the indices of the minimum and maximum values in the current window
        LinkedList<int> minDeque = new LinkedList<int>();
        LinkedList<int> maxDeque = new LinkedList<int>();

        int left = 0, right = 0, result = 0;

        while (right < nums.Length) 
        {
            // Maintain the decreasing order of values in maxDeque
            while (maxDeque.Count > 0 && nums[maxDeque.Last.Value] <= nums[right])
                maxDeque.RemoveLast();
            
            maxDeque.AddLast(right);

            // Maintain the increasing order of values in minDeque
            while (minDeque.Count > 0 && nums[minDeque.Last.Value] >= nums[right])
                minDeque.RemoveLast();
            
            minDeque.AddLast(right);

            // Check if the current window is valid
            while (nums[maxDeque.First.Value] - nums[minDeque.First.Value] > limit) 
            {
                left++;
                // Remove elements that are out of the current window from the deques
                if (minDeque.First.Value < left)
                    minDeque.RemoveFirst();
                
                if (maxDeque.First.Value < left)
                    maxDeque.RemoveFirst();
            }

            // Update the result with the size of the current valid window
            result = Math.Max(result, right - left + 1);
            right++;
        }

        return result;
    }
}