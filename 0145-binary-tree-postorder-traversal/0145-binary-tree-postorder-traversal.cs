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
    IList<int> num = new List<int>();
    
    public void dfs(TreeNode root)
    {
        if(root == null) return;
        dfs(root.left);
        dfs(root.right);
        num.Add(root.val);
    } 
    public IList<int> PostorderTraversal(TreeNode root) {
        dfs(root);
        return num;
    }
}