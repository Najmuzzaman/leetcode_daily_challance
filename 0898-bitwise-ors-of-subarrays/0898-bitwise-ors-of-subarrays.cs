public class Solution {
    public int SubarrayBitwiseORs(int[] arr) {
        HashSet<int> s = new HashSet<int>();
        HashSet<int>  ss = new HashSet<int>();
        int n=arr.Length;
        for (int i = 0; i < n; i++)
        {
            var st = new HashSet<int>();
            st.Add(arr[i]);
            foreach (var item in ss)
                st.Add(item | arr[i]);
            ss.Clear();
            foreach (var item in st)
            {
                ss.Add(item);
                s.Add(item);
            }
        }
        return s.Count;
    }
}