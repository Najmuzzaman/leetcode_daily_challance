/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int MinimumOperations(TreeNode root) {
        if (root == null) return 0;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int totalSwaps = 0;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            var levelValues = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                levelValues.Add(node.val);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            // Calculate the minimum swaps needed for the current level
            totalSwaps += MinSwapsToSort(levelValues);
        }

        return totalSwaps;
    }

    private int MinSwapsToSort(List<int> arr)
    {
        int n = arr.Count;
        var indexedArr = arr.Select((value, index) => new { value, index })
                            .OrderBy(x => x.value)
                            .ToArray();

        var visited = new bool[n];
        int swaps = 0;

        for (int i = 0; i < n; i++)
        {
            if (visited[i] || indexedArr[i].index == i)
                continue;

            int cycleSize = 0;
            int j = i;

            while (!visited[j])
            {
                visited[j] = true;
                j = indexedArr[j].index;
                cycleSize++;
            }

            if (cycleSize > 1)
                swaps += (cycleSize - 1);
        }

        return swaps;
    }
}