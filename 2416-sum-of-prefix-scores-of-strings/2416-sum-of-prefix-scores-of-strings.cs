public class Solution {
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public int PrefixCount;

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            PrefixCount = 0;
        }
    }
    
    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        // Insert a word into the Trie and increase prefix count as we go
        public void Insert(string word)
        {
            TrieNode currentNode = root;
            foreach (char ch in word)
            {
                if (!currentNode.Children.ContainsKey(ch))
                {
                    currentNode.Children[ch] = new TrieNode();
                }
                currentNode = currentNode.Children[ch];
                currentNode.PrefixCount++; // Increment prefix count at each node
            }
        }
    
        // Given a word, calculate the sum of prefix counts for all prefixes of the word
        public int GetPrefixScore(string word)
        {
            TrieNode currentNode = root;
            int score = 0;
            foreach (char ch in word)
            {
                if (currentNode.Children.ContainsKey(ch))
                {
                    currentNode = currentNode.Children[ch];
                    score += currentNode.PrefixCount; // Add the prefix count to the score
                }
                else
                {
                    break; // If we find a character that doesn't exist in the Trie, stop
                }
            }
            return score;
        }
    }
    
    public int[] SumPrefixScores(string[] words)
    {
        Trie trie = new Trie();
        
        // Insert all words into the Trie
        foreach (var word in words)
        {
            trie.Insert(word);
        }
        
        int[] result = new int[words.Length];
        
        // For each word, calculate the sum of scores of its prefixes
        for (int i = 0; i < words.Length; i++)
        {
            result[i] = trie.GetPrefixScore(words[i]);
        }
        
        return result;
    }
}