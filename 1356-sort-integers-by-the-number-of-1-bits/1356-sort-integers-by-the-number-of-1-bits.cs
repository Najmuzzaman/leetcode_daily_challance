public class Solution {
      public int[] SortByBits(int[] arr) => arr
        .OrderBy(x => BitOperations.PopCount((uint) x))
        .ThenBy(x => x)
        .ToArray();  
}