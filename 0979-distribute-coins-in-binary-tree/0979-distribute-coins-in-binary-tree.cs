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
    public int DistributeCoins(TreeNode root, TreeNode parent= null) {
        if (root==null) return 0;
        int moves=DistributeCoins(root.left,root)+DistributeCoins(root.right,root);
        int x=root.val-1;
        if (parent!=null) parent.val += x; 
        moves+= Math.Abs(x);
        return moves;
    }
}