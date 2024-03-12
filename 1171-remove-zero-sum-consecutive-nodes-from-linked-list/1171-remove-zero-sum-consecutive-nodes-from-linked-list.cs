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
    public ListNode RemoveZeroSumSublists(ListNode head) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        
        Dictionary<int, ListNode> map = new Dictionary<int, ListNode>();
        int prefixSum = 0;
        ListNode current = dummy;
        
        while (current != null) {
            prefixSum += current.val;
            
            if (map.ContainsKey(prefixSum)) {
                // Remove nodes between map[prefixSum] and current
                int sum = prefixSum;
                ListNode temp = map[sum].next;
                while (temp != current) {
                    sum += temp.val;
                    map.Remove(sum);
                    temp = temp.next;
                }
                map[prefixSum].next = current.next;
            } else {
                map[prefixSum] = current;
            }
            
            current = current.next;
        }
        
        return dummy.next;
    }
}