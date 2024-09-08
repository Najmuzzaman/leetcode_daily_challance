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
    public ListNode[] SplitListToParts(ListNode head, int k) {
        // Step 1: Determine the length of the list
        int length = 0;
        ListNode current = head;
        while (current != null) {
            length++;
            current = current.next;
        }
        
        // Step 2: Calculate size of each part
        int partSize = length / k;        // Minimum size of each part
        int extraNodes = length % k;      // Extra nodes to distribute to some parts
        
        // Step 3: Initialize the result array
        ListNode[] result = new ListNode[k];
        current = head;
        
        for (int i = 0; i < k; i++) {
            result[i] = current;  // Start of the current part
            int currentPartSize = partSize + (extraNodes > 0 ? 1 : 0);  // Distribute extra nodes
            extraNodes--;  // Reduce the count of extra nodes to distribute
            
            // Step 4: Advance the pointer to split the list
            for (int j = 0; j < currentPartSize - 1 && current != null; j++) {
                current = current.next;
            }
            
            // Step 5: Break the link to form the part and move to the next part
            if (current != null) {
                ListNode next = current.next;
                current.next = null;  // Break the link
                current = next;       // Move to the next part
            }
        }
        
        return result;
    }
}