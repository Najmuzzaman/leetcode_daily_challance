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
        StringBuilder sb1=new StringBuilder();
        StringBuilder sb2=new StringBuilder();
        if( root.left != null)
            sb1 = dfs(root.left,new StringBuilder(sb.ToString()));
        if( root.right != null)
            sb2 =  dfs(root.right,new StringBuilder(sb.ToString()));
        
        if (sb1.Length != 0 && sb2.Length != 0) {
            return sb1.ToString().CompareTo(sb2.ToString()) < 0 ? sb1 : sb2;
        } 
        else 
        {
            return sb1.Length != 0  ? sb1 : sb2;
        }
    }
    
    private StringBuilder ReverseStringBuilder(StringBuilder s) {
        int n = s.Length;
        for (int i = 0; i < n / 2; i++) {
            char temp = s[i];
            s[i] = s[n - 1 - i];
            s[n - 1 - i] = temp;
        }
        return s;
    }
}