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
    private TreeNode dfs(int[] preorder,int[] postorder, ref int preIndex, int start, int end, int n, Dictionary<int, int> postpos)
    {
        if (preIndex >= n || start > end)
            return null;

        int element = preorder[preIndex++];
        TreeNode root = new TreeNode(element);

        if (start == end)
            return root;

        int nextpos = postpos[preorder[preIndex]];

        root.left = dfs(preorder, postorder, ref preIndex, start, nextpos, n, postpos);
        root.right = dfs(preorder, postorder, ref preIndex, nextpos + 1, end - 1, n, postpos);
        
        return root;
    }
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {
        int n = preorder.Length;
        Dictionary<int, int> postpos = new Dictionary<int, int>();
        
        for (int i = 0; i < n; i++)
            postpos[postorder[i]] = i;
        
        int preIndex = 0;
        return dfs(preorder, postorder, ref preIndex, 0, n - 1, n, postpos);
    }
}