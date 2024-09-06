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
public class Solution {
     private ListNode dfs(ListNode head, HashSet<int> st) 
     {
        if (head == null) return null;
        head.next = dfs(head.next, st);
        if (st.Contains(head.val))
        {
            ListNode next = head.next;
            // No need to manually delete in C# (handled by garbage collector)
            return next;
        }
        return head;
    }
    public ListNode ModifiedList(int[] nums, ListNode head) 
    {
        HashSet<int> st = new HashSet<int>(nums);
        return dfs(head, st);
    }
}