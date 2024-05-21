public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        List<IList<int>> res = new List<IList<int>>();
        List<int> op = new List<int>();
        dfs(nums, 0, op, res);
        return res;
    }

    private void dfs(int[] nums, int start, List<int> op, List<IList<int>> res) {
        if (nums.Length == start) {
            res.Add(new List<int>(op));
            return;
        }
        dfs(nums, start + 1, op, res);
        op.Add(nums[start]);
        dfs(nums, start + 1, op, res);
        op.RemoveAt(op.Count - 1);
    }
}