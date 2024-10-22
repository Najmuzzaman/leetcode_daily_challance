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
    long[] ksum;
    long[] nsum;
    int level;
    public long KthLargestLevelSum(TreeNode root, int k)
    {
        ksum = new long[1000001];
        level = 0;
        dfs(root, level);
        level++;
        if (level < k)
            return -1;
        nsum=new long[level];
        for (int i = 0;i<level;i++)
            nsum[i]= ksum[i];

        Array.Sort(nsum, (a, b) => b.CompareTo(a));
        return nsum[k - 1];
    }
    public void dfs(TreeNode root, int pos)
    {
        level = Math.Max(level, pos);
        if(root!=null)
            ksum[pos] += root.val;
        if(root.left!=null)
            dfs(root.left, pos+1);
        if (root.right != null)
            dfs(root.right, pos + 1);
    }
}