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
public class Solution 
{
    public ListNode DoubleIt(ListNode head) 
    {
        (int, ListNode) result = dfs(head);
        if (result.Item1 != 0) 
        {
            ListNode newHead = new ListNode(result.Item1);
            newHead.next = result.Item2;
            return newHead;
        }
        return result.Item2;
    }
    private (int, ListNode) dfs(ListNode head) 
    {
        int a = head.val * 2;
        if (head.next != null) 
        {
            (int, ListNode) nextResult = dfs(head.next);
            a += nextResult.Item1;
        }
        head.val = a % 10;
        return (a / 10, head);
    }
}