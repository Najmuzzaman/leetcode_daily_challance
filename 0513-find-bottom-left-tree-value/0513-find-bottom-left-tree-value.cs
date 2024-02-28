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
    public int FindBottomLeftValue(TreeNode root) {
        int last = 0;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count() != 0) {
            int count = q.Count();
            for (int i = 0; i < count; i++) {
                TreeNode curr = q.Dequeue();
                if (i == 0)
                    last = curr.val;  // last leftMost val
                if (curr.left != null)
                    q.Enqueue(curr.left);
                if (curr.right != null)
                    q.Enqueue(curr.right);
            }
        }
        return last;
    }
}