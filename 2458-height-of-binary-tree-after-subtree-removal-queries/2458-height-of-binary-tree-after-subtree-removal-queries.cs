/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int[] TreeQueries(TreeNode root, int[] queries) {        
       Dictionary<int, int> Map = new Dictionary<int, int>();
        Dictionary<TreeNode, int> H = new Dictionary<TreeNode, int>();

        dfs(root, 0, 0, Map, H);
        int n=queries.Length;
        int[] result = new int[n];
        for(int i=0;i<n;i++)
            result[i]=Map[queries[i]];

        return result;
    }
    private int Height(TreeNode node, Dictionary<TreeNode, int> H)
    {
        if (node == null) return -1;
        if (H.ContainsKey(node)) return H[node];

        int h = 1 + Math.Max(Height(node.left, H), Height(node.right, H));
        H[node] = h;
        return h;
    }
    private void dfs(TreeNode node, int depth, int maxVal,Dictionary<int, int> Map, Dictionary<TreeNode, int> H)
    {
        if (node == null) return;

        Map[node.val] = maxVal;
        dfs(node.left, depth + 1, Math.Max(maxVal, depth + 1 + Height(node.right, H)), Map, H);
        dfs(node.right, depth + 1, Math.Max(maxVal, depth + 1 + Height(node.left, H)), Map, H);
    }
}