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
     private int gcd(int a, int b) 
     {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    
    public ListNode InsertGreatestCommonDivisors(ListNode head) 
    {
         if (head == null || head.next == null)
            return head; // No need to insert if there's only one node

        ListNode current = head;

        while (current != null && current.next != null) 
        {
            // Calculate GCD between current node and the next node
            int gcdValue = gcd(current.val, current.next.val);

            // Create a new node with the GCD value
            ListNode gcdNode = new ListNode(gcdValue);

            // Insert the new GCD node between current and next
            gcdNode.next = current.next;
            current.next = gcdNode;

            // Move to the next pair (skip over the inserted GCD node)
            current = gcdNode.next;
        }
        return head;
    }
}