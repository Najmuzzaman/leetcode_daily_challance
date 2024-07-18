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
    int ans=0;
    public int CountPairs(TreeNode root, int distance) {
        dfs(root, distance);
        return ans;
    }
    public int[] dfs(TreeNode node, int distance) {
        int[] ma = new int[11];

        if (node == null) return ma;

        if (node.left == null && node.right == null)
              ma[1] = 1;

        int[] l = dfs(node.left, distance);
        int[] r = dfs(node.right, distance);

        for (int i = 1; i < distance; i++)
            for (int j = 1; j <= distance - i; j++)
                ans += (l[i] * r[j]);

        for (int i=2; i<11; i++)
            ma[i] += l[i-1] + r[i-1];

        return ma;
    }
}