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

     private int dfs(TreeNode root, string s, ref int i, int d) {
        if (i >= s.Length)
            return 0;
        
        int cnt = 0;
        while (i < s.Length && s[i] == '-') {
            i++;
            cnt++;
        }

        if (i >= s.Length)
            return cnt;

        int ind = i;
        int val = 0;
        while (ind < s.Length && char.IsDigit(s[ind])) {
            val = val * 10 + (s[ind] - '0');
            ind++;
        }

        if (d + 1 == cnt) {
            root.left = new TreeNode(val);
            i = ind;
            cnt = dfs(root.left, s, ref i, d + 1);
        }

        if (d + 1 == cnt) {
            ind = i;
            val = 0;
            while (ind < s.Length && char.IsDigit(s[ind])) {
                val = val * 10 + (s[ind] - '0');
                ind++;
            }
            root.right = new TreeNode(val);
            i = ind;
            cnt = dfs(root.right, s, ref i, d + 1);
        }

        return cnt;
    }
    public TreeNode RecoverFromPreorder(string traversal) {
        int i = 0;
        int ind = i;
        int val = 0;
        int n= traversal.Length;
        
        while (ind < n && char.IsDigit(traversal[ind])) {
            val = val * 10 + (traversal[ind] - '0');
            ind++;
        }

        TreeNode root = new TreeNode(val);
        i = ind;
        dfs(root, traversal, ref i, 0);
        return root;
    }
}