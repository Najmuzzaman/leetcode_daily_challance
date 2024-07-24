public class Solution {
    public int[] SortJumbled(int[] mapping, int[] nums) {
        int n=nums.Length;
        var newNums = new (int i, long  M)[n];
         for (int i = 0; i < n; ++i) 
         {
             int num = nums[i];
             long mappedNum = 0;
             long placeValue = 1;

             if (num == 0) 
             {
                 mappedNum = mapping[0];
             } 
             else 
             {
                while (num > 0) 
                {
                    int digit = num % 10;
                    mappedNum += mapping[digit] * placeValue;
                    placeValue *= 10;
                    num /= 10;
                }
            }
            newNums[i] = (i, mappedNum);
        }
        Array.Sort(newNums, (a, b) => a.M.CompareTo(b.M));
        return newNums.Select(o => nums[o.i]).ToArray();
    }
}