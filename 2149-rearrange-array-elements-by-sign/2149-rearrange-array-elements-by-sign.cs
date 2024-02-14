public class Solution {
    public int[] RearrangeArray(int[] nums) {
        int n = nums.Length;
        int[] result = new int[n];
        List<int> positive=new List<int>();
        List<int> negative=new List<int>();
        for (int i=0;i<n;i++)
        {
            if (nums[i]>0)
                positive.Add(nums[i]);
            else 
                negative.Add(nums[i]);
        }
        int ind= 0;
        foreach (int i in positive )
        {
            result[ind] = i;
            ind+=2;
        }
        ind = 1;
        foreach (int i in negative)
        {
            result[ind] = i;
            ind += 2;
        }
        return result;
    }
}