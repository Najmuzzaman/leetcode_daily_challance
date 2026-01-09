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
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        if (root.left == null && root.right == null) 
            return root;
        

        Queue<TreeNode> queue = new Queue<TreeNode>();
        HashSet<TreeNode> set = new HashSet<TreeNode>();

        queue.Enqueue(root);

        while(queue.Count > 0) {
            int count = queue.Count;
            set.Clear();

            for (int i = 0; i < count; i++) {
                TreeNode node = queue.Dequeue();
                set.Add(node);

                if (node.left != null) {
                    queue.Enqueue(node.left);
                }

                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
        }

        return LCA(root, set);
    }

    private TreeNode LCA(TreeNode node, HashSet<TreeNode> set) {
        if (node == null || set.Contains(node)) {
            return node;
        }

        TreeNode left = LCA(node.left, set);
        TreeNode right = LCA(node.right, set);

        if (left != null && right != null) {
            return node;
        }

        return left ?? right;
    }
}