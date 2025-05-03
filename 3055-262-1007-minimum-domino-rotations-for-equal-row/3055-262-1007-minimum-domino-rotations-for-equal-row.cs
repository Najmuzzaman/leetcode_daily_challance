public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
        Dictionary<int, int> topCounts = new Dictionary<int, int>();
        Dictionary<int, int> bottomCounts = new Dictionary<int, int>();
        HashSet<int> allDominoValues = new HashSet<int>(tops);
        int dominoCount = tops.Length;

        foreach (int num in tops) {
            if (!topCounts.ContainsKey(num))
                topCounts[num] = 0;
            topCounts[num]++;
        }

        foreach (int num in bottoms) {
            if (!bottomCounts.ContainsKey(num))
                bottomCounts[num] = 0;
            bottomCounts[num]++;
            allDominoValues.Add(num);
        }

        List<int> candidates = new List<int>();
        foreach (int num in allDominoValues) {
            int total = 0;
            if (topCounts.ContainsKey(num))
                total += topCounts[num];
            if (bottomCounts.ContainsKey(num))
                total += bottomCounts[num];
            if (total >= dominoCount)
                candidates.Add(num);
        }

        int resultValue = -1;
        if (candidates.Count == 0)
            return resultValue;

        foreach (int candidate in candidates) {
            int i = 0;
            for (; i < dominoCount; i++) {
                if (tops[i] != candidate && bottoms[i] != candidate)
                    break;
            }
            if (i == dominoCount)
                resultValue = candidate;
        }

        if (resultValue == -1)
            return resultValue;

        int topCandidateCount = topCounts.ContainsKey(resultValue) ? topCounts[resultValue] : 0;
        int bottomCandidateCount = bottomCounts.ContainsKey(resultValue) ? bottomCounts[resultValue] : 0;

        int maxFrequency = Math.Max(topCandidateCount, bottomCandidateCount);
        return dominoCount - maxFrequency;
    }
}
