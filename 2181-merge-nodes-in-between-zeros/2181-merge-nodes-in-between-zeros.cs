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
    public ListNode MergeNodes(ListNode head) 
    {
        ListNode ptr = head;
        ListNode temp = head;
        ptr = ptr.next;
        while (ptr != null) 
        {           
            if (ptr.val == 0 && ptr.next != null) 
            {
                temp = temp.next;
                temp.val = 0;
            }
            temp.val += ptr.val;
            ptr = ptr.next;
        }
        temp.next = null;
        return head;
    }
}