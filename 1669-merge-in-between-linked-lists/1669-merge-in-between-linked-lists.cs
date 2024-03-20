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
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2) {
        ListNode node = new ListNode(0);
        node.next = list1;
        
        ListNode first = node;
        for (int i = 0; i < a; i++) {
            first = first.next;
        }
        b++;
        ListNode second = first;
        for (int i = a; i <= b ; i++) {
            second = second.next;
        }
        
        first.next = list2;
        ListNode fristlist = list2;
        while (fristlist.next != null) {
            fristlist = fristlist.next;
        }
        
        fristlist.next = second;
        
        return node.next;
    }
}