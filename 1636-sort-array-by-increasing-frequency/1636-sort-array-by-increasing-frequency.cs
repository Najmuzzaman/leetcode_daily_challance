public class Solution {
    public int[] FrequencySort(int[] nums) {
        int n = nums.Length;
        int[] mp = new int[201];
        List<int> ch=new List<int>();
        // Calculate frequencies of characters
        for(int i=0;i<n;i++)
        {
            if(mp[nums[i]+100]==0) ch.Add(nums[i]+100);
            mp[nums[i]+100]++;
        }
        int[] chars=ch.ToArray();
        Array.Sort(chars, (a, b) => {
        int cmp = mp[a] - mp[b]; // Compare frequencies in asc order
        return cmp == 0 ? b - a : cmp; // If frequencies are equal, sort by character value
        });
        int j = 0;
        foreach (int c in chars)
        {
            while (mp[c] != 0)
            {
                nums[j++] = c-100;
                mp[c]--;
            }
        }
        return nums;
    }
}