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
    int val =0; 
    public TreeNode BstToGst(TreeNode root) {
        if (root.right != null) BstToGst(root.right);
        val = root.val = val + root.val;
        if (root.left != null) BstToGst(root.left);
        return root;
    }
}