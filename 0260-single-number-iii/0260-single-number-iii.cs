public class Solution {
    public int[] SingleNumber(int[] nums) {
        Dictionary<int,int> num = new Dictionary<int,int>();
        List<int> list = new List<int>();
        foreach (int i in nums)
        {
            if (num.ContainsKey(i))
            {
                num[i]++;
                list.Remove(i);
            }
            else
            {
                num[i] = 1;
                list.Add(i);
            }
        }
        return list.ToArray();
    }
}