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
     private int mod = (int)Math.Pow(10, 9)+7;
    private long totalSum = 0;
    private long maxV = 0;
    private long dfs1(TreeNode root)
    {
        if(root == null)
            return 0;

        return root.val + dfs1(root.left) + dfs1(root.right);
    }
    private long dfs(TreeNode root)
    {
        if(root == null)
            return 0;

        long leftSub = dfs(root.left);
        long rightSub = dfs(root.right);
        long sum = (root.val+leftSub+rightSub);
       
        long cur = (totalSum-sum)*sum;
        maxV = Math.Max(cur, maxV);
        return sum;
    }
    public int MaxProduct(TreeNode root) {
        totalSum = dfs1(root);
        dfs(root);
        return (int)(maxV%mod);
    }
}