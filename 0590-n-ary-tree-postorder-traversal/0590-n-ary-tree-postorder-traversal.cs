/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    IList<int> ans=new List<int>();
     private void dfs(Node node) 
     {
        if (node == null) return;
        foreach (var child in node.children) 
            dfs(child);
        ans.Add(node.val);
    }
    public IList<int> Postorder(Node root)
    {
        dfs(root);
        return ans;
    }
}