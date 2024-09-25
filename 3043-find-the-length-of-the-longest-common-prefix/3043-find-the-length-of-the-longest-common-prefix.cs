public class Solution {
    
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsEndOfNumber = false; // To mark the end of a number
    }

    public class Trie
    {
        private TrieNode root = new TrieNode();

        // Insert a number (as a string) into the Trie
        public void Insert(string number)
        {
            TrieNode current = root;
            foreach (char digit in number)
            {
                if (!current.Children.ContainsKey(digit))
                {
                    current.Children[digit] = new TrieNode();
                }
                current = current.Children[digit];
            }
            current.IsEndOfNumber = true;
        }

        // Find the longest common prefix length between the current number and numbers in the Trie
        public int FindLongestCommonPrefix(string number)
        {
            TrieNode current = root;
            int commonPrefixLength = 0;

            foreach (char digit in number)
            {
                if (current.Children.ContainsKey(digit))
                {
                    commonPrefixLength++;
                    current = current.Children[digit];
                }
                else
                {
                    break; // As soon as a digit doesn't match, stop
                }
            }

            return commonPrefixLength;
        }
    }
    public int LongestCommonPrefix(int[] arr1, int[] arr2) 
    {
        Trie trie = new Trie();
        
        // Insert all numbers from arr2 into the Trie as strings
        foreach (int num in arr2)
        {
            trie.Insert(num.ToString());
        }

        int maxLCP = 0;
        
        // For each number in arr1, find the longest common prefix with numbers from arr2
        foreach (int num in arr1)
        {
            int lcpLength = trie.FindLongestCommonPrefix(num.ToString());
            maxLCP = Math.Max(maxLCP, lcpLength);
        }
        
        return maxLCP;
    }
}