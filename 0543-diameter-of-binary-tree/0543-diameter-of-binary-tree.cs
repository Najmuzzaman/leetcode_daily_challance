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
    public int Dia;    
    public int DiameterOfBinaryTree(TreeNode root) {
        Dia=0;
        findDia(root);
        return Dia;
    }    
    public int findDia(TreeNode root){
        if(root == null) return 0;
        int leftDepth = findDia(root.left);
        int rightDepth = findDia(root.right);
        int currDia = leftDepth + rightDepth;
        Dia = Math.Max(Dia, currDia);
        return 1 + Math.Max(leftDepth, rightDepth);
    }
}