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
    private const int N = 1001;
    private bool[] rmv = new bool[N];
    private List<TreeNode> ans = new List<TreeNode>();
    
    private void dfs(TreeNode r, TreeNode p, bool isLeft) {
        if (r == null) return;
        
        if (rmv[r.val]) {
            if (p != null) {
                if (isLeft) p.left = null;
                else p.right = null;
            }
            dfs(r.left, null, true);
            dfs(r.right, null, false);
        } 
        else {
            if (p == null) 
                ans.Add(r);
            
            dfs(r.left, r, true);
            dfs(r.right, r, false);
        }
    }
    
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        foreach (int x in to_delete) 
            rmv[x] = true;

        dfs(root, null, true);
        return ans;
    }
}