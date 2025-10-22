public class Solution {
    public int MaxFrequency(int[] nums, int k, int numOperations) {
        int len = nums.Length;
        long maxFreq = 0;
        Dictionary<int, int> dict = new();
       
        Array.Sort(nums); // sort array

        int res = 0, i = 0, j = 0;
        foreach(int n in nums) // keep items in the range: n +-k;
        {
            while(j < len && nums[j] <= n+k) 
            {
                if(!dict.ContainsKey(nums[j]))
                    dict.Add(nums[j], 1);
                else
                    dict[nums[j]]++;

                j++;
            }

            while(i < len && nums[i] < n-k)
            {
                if(--dict[nums[i]] == 0)
                    dict.Remove(nums[i]);
                    
                i++;
            }              

            int cur = Math.Min(j-i, dict[n]+numOperations);
            res = Math.Max(cur, res);
        }

        for(int p = 0, q = 0; q < len; q++)
        {
            while(p < len && nums[p] + 2*k <nums[q]) // remove out of range items
            {
                p++;
            }

            res = Math.Max(res, Math.Min(q-p+1, numOperations));
        }

        return res;
    }
}