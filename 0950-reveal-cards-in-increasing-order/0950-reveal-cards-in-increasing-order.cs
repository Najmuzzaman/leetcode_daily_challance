public class Solution {
    public int[] DeckRevealedIncreasing(int[] deck) {
        Array.Sort(deck); // Sort the deck in increasing order
        int n = deck.Length;
        Queue<int> indexQueue = new Queue<int>();
        for (int i = 0; i < n; i++) {
            indexQueue.Enqueue(i); // Enqueue indices from 0 to n-1
        }
        
        int[] result = new int[n];
        foreach (int card in deck) {
            result[indexQueue.Dequeue()] = card; // Assign cards to indices in increasing order
            if (indexQueue.Count > 0) {
                indexQueue.Enqueue(indexQueue.Dequeue()); // Move the index to the bottom
            }
        }
        return result;
    }
}