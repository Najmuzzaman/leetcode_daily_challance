/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
   private bool dfs(ListNode head, TreeNode root) 
   {
        // If we've exhausted the linked list, it means we've found a path
        if (head == null) return true;
        
        // If the tree node is null or the values don't match, return false
        if (root == null || root.val != head.val) return false;
        
        // Recursively check the left and right subtrees for the next node in the list
        return dfs(head.next, root.left) || dfs(head.next, root.right);
    }
    public bool IsSubPath(ListNode head, TreeNode root) 
    {
        if (root == null) return false;
        
        // Check if there's a matching path starting from this root node
        if (dfs(head, root)) return true;
        
        // Otherwise, check the left and right subtrees
        return IsSubPath(head, root.left) || IsSubPath(head, root.right);
    }
}