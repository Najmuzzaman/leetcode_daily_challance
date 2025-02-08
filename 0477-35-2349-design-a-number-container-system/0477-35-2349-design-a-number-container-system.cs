public class NumberContainers {
   private Dictionary<int, SortedSet<int>> numberToIndices;
    private Dictionary<int, int> indexToNumbers;
    public NumberContainers() {
        numberToIndices = new Dictionary<int, SortedSet<int>>();
        indexToNumbers = new Dictionary<int, int>();
    }
    
    public void Change(int index, int number) {
        if (indexToNumbers.ContainsKey(index)) {
            int previousNumber = indexToNumbers[index];
            numberToIndices[previousNumber].Remove(index);

            // Remove the number entry if no indices are left
            if (numberToIndices[previousNumber].Count == 0) {
                numberToIndices.Remove(previousNumber);
            }
        }

        indexToNumbers[index] = number;
        if (!numberToIndices.ContainsKey(number)) {
            numberToIndices[number] = new SortedSet<int>();
        }
        numberToIndices[number].Add(index);
    }
    
    public int Find(int number) {
         if (numberToIndices.ContainsKey(number) && numberToIndices[number].Count > 0) {
            // Return the smallest index
            return numberToIndices[number].Min;
        }
        return -1;
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */