public class Solution {
    public int MaxWidthRamp(int[] nums) {
        int n=nums.Length;
        Stack<int> st = new Stack<int>();
        st.Push(0);
        for(int i=0;i<n;i++)
        {
            int s=st.First();
            if (nums[s] > nums[i])
                st.Push(i);
        }
        int ans = 0;
        for(int i=n-1;i>=0;i--)
        {
            while(st.Count!=0 && nums[i] >= nums[st.First()])
            {
                ans = Math.Max(ans, i - st.First());
                st.Pop();
            }
        }
        return ans;
    }
}