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
    public string SmallestFromLeaf(TreeNode root) {
        return dfs(root, new StringBuilder()).ToString();
    }
    
    private StringBuilder dfs(TreeNode root, StringBuilder sb) {
        if (root == null) {
            return sb;
        }
        sb.Append((char)('a' + root.val));
        if (root.left == null && root.right == null) {
            return ReverseStringBuilder(sb);
        }
        
        StringBuilder sb1 =root.left != null ? dfs(root.left,new StringBuilder(sb.ToString())) : new StringBuilder();
        StringBuilder sb2 =  root.right != null ? dfs(root.right,new StringBuilder(sb.ToString())) : new StringBuilder();
        
        if (sb1.Length != 0 && sb2.Length != 0)
            return sb1.ToString().CompareTo(sb2.ToString()) < 0 ? sb1 : sb2;
        else 
            return sb1.Length != 0  ? sb1 : sb2;
    }
    
    private StringBuilder ReverseStringBuilder(StringBuilder sb) {
        char[] arr = sb.ToString().ToCharArray();
        Array.Reverse(arr);
        return new StringBuilder(new string(arr));
    }
}