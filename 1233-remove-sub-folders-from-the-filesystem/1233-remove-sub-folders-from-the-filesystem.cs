public class Solution {
    class TrieNode
    {
        public bool isEnd;
        public Dictionary<string, TrieNode> children;
        public TrieNode()
        { 
            isEnd = false;
            children=new Dictionary<string, TrieNode>();
        }
    }
    public Solution()
    {
        root = new TrieNode();
    }
    TrieNode root;
    public void Dispose()
    {
        DeleteTrie(root);
    }
    private void DeleteTrie(TrieNode node)
    {
        if (node == null) return;
        foreach (var pair in node.children)
        {
            DeleteTrie(pair.Value);
        }
        node.children.Clear();
    }
    public IList<string> RemoveSubfolders(string[] folder)
    {
        foreach (string path in folder)
        {
            TrieNode currentNode = root;
            using (StringReader reader = new StringReader(path))
            {
                string folderName;

                while ((folderName = ReadNextFolder(reader)) != null)
                {
                    if (!currentNode.children.ContainsKey(folderName))
                    {
                        currentNode.children[folderName] = new TrieNode();
                    }
                    currentNode = currentNode.children[folderName];
                }
                currentNode.isEnd = true;
            }
        }
        List<string> result = new List<string>();
        foreach (string path in folder)
        {
            TrieNode currentNode = root;
            using (StringReader reader = new StringReader(path))
            {
                string folderName;
                bool isSubFolder = false;

                while ((folderName = ReadNextFolder(reader)) != null)
                {
                    if (currentNode.children.TryGetValue(folderName, out var nextNode))
                    {
                        if (nextNode.isEnd && reader.Peek() != -1)
                        {
                            isSubFolder = true;
                            break;
                        }
                        currentNode = nextNode;
                    }
                }
                if (!isSubFolder) result.Add(path);
            }
        }

        return result;
    }
    private string ReadNextFolder(StringReader reader)
    {
        int ch;
        string folderName = "";

        while ((ch = reader.Read()) != -1)
        {
            if (ch == '/')
            {
                if (folderName.Length > 0)
                {
                    return folderName;
                }
            }
            else
            {
                folderName += (char)ch;
            }
        }

        return folderName.Length > 0 ? folderName : null;
    }
}