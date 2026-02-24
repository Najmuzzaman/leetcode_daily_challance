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
    private int sum = 0;
    public int SumRootToLeaf(TreeNode root) {
        dfs(root, 0);
        return sum;
    }
    private void dfs(TreeNode node, int s)
    {
        var val = s * 2 + node.val;
        if(node.left != null)
        {
            dfs(node.left, val);
        }
        if(node.right != null)
        {
            dfs(node.right, val);  
        }
        if(node.left == null && node.right == null)
        {
            sum += val;
        }
    }
}