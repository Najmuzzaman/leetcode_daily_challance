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
    public bool FlipEquiv(TreeNode root1, TreeNode root2) {
        return dfs(root1,root2);
        
    }
    bool dfs(TreeNode node1, TreeNode node2)
    {
        if(node1==null && node2==null) return true;
        if(node1!=null && node2==null) return false;
        if(node1==null && node2!=null) return false;
        
        if(node1.val!=node2.val) return false;
        if (checkNodeValues(node1.left, node2.left) &&  checkNodeValues(node1.right, node2.right)) 
        {
            return dfs(node1.left, node2.left) && dfs(node1.right, node2.right);
        } 
        else if (checkNodeValues(node1.left, node2.right) && checkNodeValues(node1.right, node2.left))
        {
            return dfs(node1.left, node2.right) && dfs(node1.right, node2.left);
        }
        else return false;
    }
    bool checkNodeValues(TreeNode node1, TreeNode node2)
    {
        if (node1 == null && node2 == null) return true;
        if (node1 !=null && node2 != null && node1.val == node2.val) 
            return true;
        return false;
    }
}