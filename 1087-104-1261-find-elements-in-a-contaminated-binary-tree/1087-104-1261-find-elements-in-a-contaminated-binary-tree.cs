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
public class FindElements {
 private HashSet<int> values;
    public FindElements(TreeNode root) {
        values = new HashSet<int>();
        if (root != null) {
            root.val = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            
            while (queue.Count > 0) {
                TreeNode node = queue.Dequeue();
                values.Add(node.val);
                
                if (node.left != null) {
                    node.left.val = node.val * 2 + 1;
                    queue.Enqueue(node.left);
                }
                
                if (node.right != null) {
                    node.right.val = node.val * 2 + 2;
                    queue.Enqueue(node.right);
                }
            }
        }
    }
    
    public bool Find(int target) {
         return values.Contains(target);
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * bool param_1 = obj.Find(target);
 */