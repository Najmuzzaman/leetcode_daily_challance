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
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        return dfs(root).Node;
    }
    public (TreeNode Node, int Depth) dfs(TreeNode root) {
        if(root == null) return (null, 0);

        var l = dfs(root.left);
        var r = dfs(root.right);

        if(l.Depth == r.Depth) return (root, l.Depth + 1);
        if(l.Depth > r.Depth) return (l.Node, l.Depth + 1);
        return (r.Node, r.Depth + 1);
    }
}