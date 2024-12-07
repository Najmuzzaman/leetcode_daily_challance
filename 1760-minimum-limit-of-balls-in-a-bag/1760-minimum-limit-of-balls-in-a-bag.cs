public class Solution {
    public int MinimumSize(int[] nums, int maxOperations) {
        int n = nums.Length;
        int start = 0;
        int end = nums.Max();
        while(start<end)
        {
            int mid=(start+end)/2;
            if(check(mid,nums,maxOperations))
                end = mid;
            else
                start = mid + 1;
        }
        return start;
    }
    public bool check(int val, int[] nums, int Operation)
    {
        int total = 0;
        foreach(int n in nums)
        {
            int oper =(int)Math.Ceiling((double)n /val)-1;
            total += oper;
            if(total>Operation) return false;
        }
        return true;
    }
}