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
    public TreeNode AddOneRow(TreeNode root, int val, int depth) 
    {
        if (depth == 1)
        {
            TreeNode r = new TreeNode(val);
            r.left = root;
            return r;
        }

        return Add(root, val, depth, 1);
    }
    
    TreeNode Add(TreeNode root, int val, int depth, int curr)
    {
        if (root == null)
            return null;

        if (curr == depth - 1) 
        {
            TreeNode left = root.left;
            TreeNode right = root.right;

            root.left = new TreeNode(val);
            root.right = new TreeNode(val);
            root.left.left = left;
            root.right.right = right;

            return root;
        }

        root.left = Add(root.left, val, depth, curr + 1);
        root.right = Add(root.right, val, depth, curr + 1);

        return root;
    }
}