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
    public bool IsEvenOddTree(TreeNode root) {
        if (root == null) {
            return true;
        }
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        bool flag = true;
        queue.Enqueue(root);
        
        while (queue.Count > 0) {
            int size = queue.Count;
            int prev = flag ? int.MinValue : int.MaxValue;
            
            for (int i = 0; i < size; i++) {
                TreeNode node = queue.Dequeue();
                
                if (flag) {
                    if (node.val % 2 == 0 || node.val <= prev) {
                        return false;
                    }
                } else {
                    if (node.val % 2 == 1 || node.val >= prev) {
                        return false;
                    }
                }
                
                if (node.left != null) {
                    queue.Enqueue(node.left);
                }
                
                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
                
                prev = node.val;
            }
            
            flag = !flag;
        }
        
        return true;
    }
}