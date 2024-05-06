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
      public ListNode reverseList(ListNode head) {
        ListNode p = null;
        ListNode c = head;

        while (c != null) {
            ListNode n = c.next;
            c.next = p;
            p = c;
            c = n;
        }

        return p;
    }
    
    public ListNode RemoveNodes(ListNode head) {
        ListNode reversedHead = reverseList(head);

        ListNode c = reversedHead;
        int ma = Int32.MinValue;
        ListNode p = null;

        while (c != null) 
        {
            if (c.val < ma)
            {
                p.next = c.next;
            } 
            else
            {
                ma = c.val;
                p = c;
            }
            c = c.next;
        }

        return reverseList(reversedHead);
    }
}