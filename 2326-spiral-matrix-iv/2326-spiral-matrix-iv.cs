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
    public int[][] SpiralMatrix(int m, int n, ListNode head) {
        // Initialize the matrix with -1
        int[][] matrix = new int[m][];
        for (int i = 0; i < m; i++) 
        {
            matrix[i] = new int[n];
            for (int j = 0; j < n; j++)
                matrix[i][j] = -1;
        }

        // Define boundaries for the spiral traversal
        int top = 0, bottom = m - 1, left = 0, right = n - 1;
        ListNode current = head;

        // Fill the matrix in a spiral order
        while (current != null && top <= bottom && left <= right) 
        {
            // Traverse from left to right across the top row
            for (int j = left; j <= right && current != null; j++) 
            {
                matrix[top][j] = current.val;
                current = current.next;
            }
            top++; // Move the top boundary down

            // Traverse from top to bottom along the right column
            for (int i = top; i <= bottom && current != null; i++) 
            {
                matrix[i][right] = current.val;
                current = current.next;
            }
            right--; // Move the right boundary left

            // Traverse from right to left across the bottom row
            for (int j = right; j >= left && current != null; j--)
            {
                matrix[bottom][j] = current.val;
                current = current.next;
            }
            bottom--; // Move the bottom boundary up

            // Traverse from bottom to top along the left column
            for (int i = bottom; i >= top && current != null; i--) 
            {
                matrix[i][left] = current.val;
                current = current.next;
            }
            left++; // Move the left boundary right
        }

        return matrix;
    }
}