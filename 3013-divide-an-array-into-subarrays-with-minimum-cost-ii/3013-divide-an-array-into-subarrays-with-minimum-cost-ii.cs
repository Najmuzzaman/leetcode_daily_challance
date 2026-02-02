public class Solution {
    // Custom comparer for sorting by value first, then by index
    private class ValueIndexComparer : IComparer<(int value, int index)> {
        public int Compare((int value, int index) a, (int value, int index) b) {
            if (a.value != b.value)                                 // If values are different, compare by value
                return a.value.CompareTo(b.value);
            return a.index.CompareTo(b.index);                      // If values are same, compare by index to handle duplicates
        }
    }

    public long MinimumCost(int[] nums, int k, int dist) {
        int n = nums.Length;                                        // Get array length

        // SortedSet to maintain k-1 smallest elements in current window
        SortedSet<(int value, int index)> kMinimum = new SortedSet<(int value, int index)>(new ValueIndexComparer());

        // SortedSet to maintain remaining larger elements in current window
        SortedSet<(int value, int index)> remaining = new SortedSet<(int value, int index)>(new ValueIndexComparer());

        long sum = 0;                                               // Sum of k-1 smallest elements in current window
        int i = 1;                                                  // Start from index 1 (index 0 is fixed)

        // Build first window [1 ... dist+1]
        while (i < n && i - dist < 1) {                             // Continue while within first window range
            var cur = (nums[i], i);                                 // Create tuple with current value and index
            kMinimum.Add(cur);                                      // Add current element to kMinimum set
            sum += nums[i];                                         // Add current value to sum

            if (kMinimum.Count > k - 1) {                           // If kMinimum has more than k-1 elements
                var largest = kMinimum.Max;                         // Get the largest element in kMinimum
                kMinimum.Remove(largest);                           // Remove it from kMinimum
                sum -= largest.value;                               // Subtract its value from sum
                remaining.Add(largest);                             // Add it to remaining set
            }
            i++;                                                    // Move to next index
        }

        long result = long.MaxValue;                                // Initialize result with maximum value

        // Sliding window from dist+2 onwards
        while (i < n) {                                             // Continue until end of array
            var cur = (nums[i], i);                                 // Create tuple with current value and index
            kMinimum.Add(cur);                                      // Add current element to kMinimum
            sum += nums[i];                                         // Add current value to sum

            if (kMinimum.Count > k - 1) {                           // If kMinimum has more than k-1 elements
                var largest = kMinimum.Max;                         // Get the largest element in kMinimum
                kMinimum.Remove(largest);                           // Remove it from kMinimum
                sum -= largest.value;                               // Subtract its value from sum
                remaining.Add(largest);                             // Add it to remaining set
            }

            result = Math.Min(result, sum);                         // Update result with minimum sum found so far

            // Remove expired index (element at i - dist)
            int remIdx = i - dist;                                  // Calculate index of element to remove (outside window)
            var toRemove = (nums[remIdx], remIdx);                  // Create tuple for element to remove

            if (kMinimum.Remove(toRemove)) {                        // Try to remove from kMinimum; if successful
                sum -= nums[remIdx];                                // Subtract removed value from sum

                if (remaining.Count > 0) {                          // If remaining set is not empty
                    var promote = remaining.Min;                    // Get smallest element from remaining
                    remaining.Remove(promote);                      // Remove it from remaining
                    kMinimum.Add(promote);                          // Add it to kMinimum (promotion)
                    sum += promote.value;                           // Add its value to sum
                }
            } else {                                                // If element was not in kMinimum
                remaining.Remove(toRemove);                         // Remove it from remaining set instead
            }

            i++;                                                    // Move to next index
        }

        return nums[0] + result;                                    // Return first element plus minimum sum of k-1 elements
    }
}