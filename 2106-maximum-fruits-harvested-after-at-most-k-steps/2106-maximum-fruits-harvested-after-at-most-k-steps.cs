public class Solution {
    public int MaxTotalFruits(int[][] fruits, int startPos, int k) {
         List<int[]> lefts = new List<int[]>(); // summed fruits to the left and right
        List<int[]> rights = new List<int[]>();
        int[][] lA; // arrayed versions after they've been found
        int[][] rA; // so they can be searched

        int allLeft; // 4 possible solutions, 1 is guaranteed to be the answer
        int allRight; // either all of a single direction
        int altLeft = 0; // or start one and alternate back
        int altRight = 0;
        
        int baseVal = 0;
        int start = binarySearch(fruits, startPos);
        int left; // directional start positions
        int right;        

        if (start >= 0) // this fruit is collected in all runs
        // separate from the run itself
        {
            baseVal = fruits[start][1];
            left = start -1;
            right = start +1;
        }
        else
        {
            start = ~start;            
            right = start;
            left = start -1;
        }

        int target = startPos - k; // max left destination        
        int pos = left;        
        int sum = 0;
        while ((pos >= 0) && (fruits[pos][0] >= target))
        {
            sum += fruits[pos][1];
            lefts.Add(new int[2] {startPos - fruits[pos][0], sum});
            pos--;
        }

        allLeft = sum; // solution 1: all left               

        target = startPos + k; // max right destination
        pos = right;
        sum = 0;
        while ((pos < fruits.Length) && (fruits[pos][0] <= target))
        {
            sum += fruits[pos][1];
            rights.Add(new int[2] {fruits[pos][0] - startPos, sum});
            pos++;
        }

        allRight = sum; // solution 2: all right        
        
        // with sum data tested, the direction switch lookups can be quickly done now
        lA = lefts.ToArray();
        rA = rights.ToArray();        
                
        if (lefts.Count > 0) // start left, switch = solution 3
        {            
            target = k/2; // short switch portion
            pos = 0;            
            
            while ((pos < lefts.Count) && (lefts[pos][0] <= target))
            {                
                sum = lefts[pos][1];
                int remain = k - (lefts[pos][0] * 2);
                if (rights.Count > 0)
                {                    
                    int index = binarySearch(rA, remain);
                    if (index < 0)
                    {
                        index = ~index;                                                
                        index--;
                        if (index >= 0) sum += rA[index][1];                        
                    }
                    else sum += rA[index][1];
                    altLeft = Math.Max(altLeft, sum);                    
                }
                pos++;
            }
        }        

        if (rights.Count > 0) // start right, switch = solution 4
        {            
            target = k/2; // short switch portion
            pos = 0;
            
            while ((pos < rights.Count) && (rights[pos][0] <= target))
            {
                sum = rights[pos][1];
                int remain = k - (rights[pos][0] * 2);                
                if (lefts.Count > 0)
                {
                    int index = binarySearch(lA, remain);                    
                    if (index < 0)
                    {
                        index = ~index;                                                
                        index--;
                        if (index >= 0) sum += lA[index][1];                        
                    }
                    else sum += lA[index][1];
                    altRight = Math.Max(altRight, sum);
                }
                pos++;
            }
        }        

        // pick the best, add in any starting fruits
        int result = 0;
        result = Math.Max(result, allLeft);        
        result = Math.Max(result, allRight);
        result = Math.Max(result, altLeft);
        result = Math.Max(result, altRight);
        result += baseVal;

        return result;
    }

    private int binarySearch(int[][] fruits, int target)
    {
        // version of binary search that will work for [][]
        // based on the 2nd index's '0' (position)
        // relative to the 1st
        // modified to work on the library function standard

        int low = 0;
        int high = fruits.Length-1;
        int nextBest = fruits.Length; 
        // non-exact match returns the first value higher
        // array length in case of total failure

        while (low <= high)
        {
            int mid = high - ((high - low) / 2);
            
            if (fruits[mid][0] == target) return mid; // no dupes, guaranteed match

            if (fruits[mid][0] > target)
            {
                nextBest = mid;
                high = mid - 1;
            }
            else low = mid + 1;
        }

        return ~nextBest;
    }
}