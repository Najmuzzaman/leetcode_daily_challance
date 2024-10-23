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
    private Dictionary<int, int> Sum = new Dictionary<int, int>();
    private Dictionary<TreeNode, TreeNode> Map = new Dictionary<TreeNode, TreeNode>();
    private Dictionary<TreeNode, bool> visit = new Dictionary<TreeNode, bool>();
    
    public TreeNode ReplaceValueInTree(TreeNode root) {
        dfs(root, null, 0);
        dfsSiblingRemove(root, 0,"");
        
        return root;
    }
    private void dfs(TreeNode node, TreeNode parent, int depth)
    {
        if (node == null) return;
        
        if (!Sum.ContainsKey(depth))
            Sum[depth] = 0;
        
        Sum[depth] += node.val;
        
        if (parent != null)
            Map[node] = parent;
        
        dfs(node.left, node, depth + 1);
        dfs(node.right, node, depth + 1);
    }
    
    private void dfsSiblingRemove(TreeNode node, int depth,string hand)
    {
        if (node == null) return;        
        
        int totalSum = Sum[depth];
        
        int siblingSum = 0;
        if (Map.ContainsKey(node)) {
            TreeNode parent = Map[node];
            if (parent.left != null && !visit.ContainsKey(node)) siblingSum += parent.left.val;
            if (parent.right != null) 
            {
                siblingSum += parent.right.val;
                parent.right.val = siblingSum;
            }
        }
        else
            siblingSum += totalSum;
        int ans = totalSum - siblingSum;
        if(ans==0 && depth>=2 && hand=="right")
        {
            if (Map.ContainsKey(node))
            {
                TreeNode parent = Map[node];
                if(parent.left != null)
                {
                    ans= parent.left.val;
                }
            }
        }
        node.val = ans;
        visit[node]=true;
        dfsSiblingRemove(node.left, depth + 1,"left");
        dfsSiblingRemove(node.right, depth + 1, "right");
    }
    
    
}