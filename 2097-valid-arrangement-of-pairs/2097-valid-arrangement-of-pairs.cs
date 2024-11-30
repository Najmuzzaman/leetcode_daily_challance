public class Solution {
    public int[][] ValidArrangement(int[][] pairs) {
        Dictionary<int, Queue<int>> linkList = new Dictionary<int, Queue<int>>();
        Dictionary<int, int> inDegree = new Dictionary<int, int>();
        Dictionary<int, int> outDegree = new Dictionary<int, int>();


        foreach (int[] pair in pairs)
        {
            int start = pair[0], end = pair[1];
            if (!linkList.ContainsKey(start))
                linkList[start] = new Queue<int>();
            linkList[start].Enqueue(end);

            if (!outDegree.ContainsKey(start))
                outDegree[start] = 0;
            if (!inDegree.ContainsKey(end))
                inDegree[end] = 0;

            outDegree[start]++;
            inDegree[end]++;
        }

        List<int> result = new List<int>();


        int startNode = -1;
        foreach (var kvp in outDegree)
        {
            int node = kvp.Key;
            if (outDegree[node] == (inDegree.ContainsKey(node) ? inDegree[node] : 0) + 1)
            {
                startNode = node;
                break;
            }
        }


        if (startNode == -1)
        {
            startNode = pairs[0][0];
        }

        Stack<int> nodeStack = new Stack<int>();
        nodeStack.Push(startNode);


        while (nodeStack.Count > 0)
        {
            int node = nodeStack.Peek();
            if (linkList.ContainsKey(node) && linkList[node].Count > 0)
            {
                int nextNode = linkList[node].Dequeue();
                nodeStack.Push(nextNode);
            }
            else
            {
                result.Add(node);
                nodeStack.Pop();
            }
        }
        result.Reverse();

        int[][] ans = new int[result.Count - 1][];
        for (int i = 1; i < result.Count; i++)
            ans[i - 1] = new int[] { result[i - 1], result[i] };

        return ans;
    }
}