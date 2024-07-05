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
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        ListNode pr = head;
        ListNode c = head.next;
        int[] ans = new int[] { -1, -1 };
        int preP = -1, cp = -1, fp = -1, p = 1;
        
        while (c.next != null) {
            if ((c.val < pr.val && c.val < c.next.val) || (c.val > pr.val && c.val > c.next.val)) {
                preP = cp;
                cp = p;

                if (fp == -1) {
                    fp = p;
                }

                if (preP != -1) {
                    if (ans[0] == -1) {
                        ans[0] = cp - preP;
                    } else {
                        ans[0] = Math.Min(ans[0], cp - preP);
                    }

                    ans[1] = p - fp;
                }
            }
            p++;
            pr = c;
            c = c.next;
        }
        return ans; 
    }
}