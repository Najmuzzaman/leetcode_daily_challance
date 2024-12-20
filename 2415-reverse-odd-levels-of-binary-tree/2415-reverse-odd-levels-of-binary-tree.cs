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
    public TreeNode ReverseOddLevels(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool reverseLevel = false;

        while (queue.Count > 0) {
            int levelSize = queue.Count;

            List<TreeNode> levelNodes = new List<TreeNode>();
            for (int i = 0; i < levelSize; i++) {
                TreeNode node = queue.Dequeue();
                levelNodes.Add(node);

                if (node.left != null) {
                    queue.Enqueue(node.left);
                }
                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }

            if (reverseLevel) {
                ReverseNodes(levelNodes);
            }
            reverseLevel = !reverseLevel;
        }

        return root;

    }
    private void ReverseNodes(List<TreeNode> nodes) {
        int left = 0, right = nodes.Count - 1;
        while (left < right) {
            int temp = nodes[left].val;
            nodes[left].val = nodes[right].val;
            nodes[right].val = temp;
            left++;
            right--;
        }
    }
}