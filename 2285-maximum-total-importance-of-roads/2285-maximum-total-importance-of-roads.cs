public class Solution {
    public long MaximumImportance(int n, int[][] roads) {
        int[] dgr = new int[n];

        // Calculate the degree of each city
        foreach (var road in roads) {
            dgr[road[0]]++;
            dgr[road[1]]++;
        }

        // Create a list of cities and sort by degree
        List<int> cities = new List<int>(Enumerable.Range(0, n));
        cities.Sort((a, b) => dgr[b].CompareTo(dgr[a]));

        // Assign values to cities starting from the highest degree
        long Ans = 0;
        for (int i = 0; i < n; i++) {
            Ans += (long)(n - i) * dgr[cities[i]];
        }

        return Ans;
    }
}