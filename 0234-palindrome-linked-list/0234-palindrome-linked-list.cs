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
    public bool IsPalindrome(ListNode head) {
         List<int> values = new List<int>();

        // Traverse the linked list and store values in the list
        while (head != null) {
            values.Add(head.val);
            head = head.next;
        }

        // Use two pointers to check if the list of values forms a palindrome
        int left = 0;
        int right = values.Count - 1;
        while (left < right) {
            if (values[left] != values[right])
                return false;
            left++;
            right--;
        }

        return true;
    }
}