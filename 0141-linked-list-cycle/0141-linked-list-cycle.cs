/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        ListNode first = head;
        ListNode last = head;
        
		
        while(first != null && first.next != null)
        {
            first = first.next.next;
            last = last.next;
            if(first == last)
                return true;
        }
        return false;
    }
}