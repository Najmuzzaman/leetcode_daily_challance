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
    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        root = LCA(root, startValue, destValue);
        StringBuilder pathFrom = new StringBuilder();
        StringBuilder pathTo = new StringBuilder();
        Dfs(root, startValue, pathFrom, true);
        Dfs(root, destValue, pathTo);
        return pathFrom.ToString() + pathTo.ToString();
    }
   public static TreeNode LCA(TreeNode root, int x, int y) {
        if (root == null || root.val == x || root.val == y)
            return root;
        TreeNode l = LCA(root.left, x, y);
        TreeNode r = LCA(root.right, x, y);
        if (l == null) return r;
        if (r == null) return l;
        return root;
    }

    public static bool Dfs(TreeNode root, int x, StringBuilder path, bool rev = false) {
        if (root == null) return false;
        if (root.val == x) return true;

        path.Append(rev ? 'U' : 'L');
        if (Dfs(root.left, x, path, rev)) return true;
        path.Length--;

        path.Append(rev ? 'U' : 'R');
        if (Dfs(root.right, x, path, rev)) return true;
        path.Length--;
        return false;
    }
} 