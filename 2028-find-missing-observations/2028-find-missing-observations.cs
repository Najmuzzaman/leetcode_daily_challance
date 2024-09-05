public class Solution {
    public int[] MissingRolls(int[] rolls, int mean, int n) {
        // Calculate the total number of rolls (n + m)
        int m = rolls.Length;
        int totalRolls = n + m;

        // Calculate the total sum of all rolls needed to achieve the given mean
        int totalSum = totalRolls * mean;

        // Calculate the sum of the known rolls
        int knownSum = 0;
        foreach (var roll in rolls) {
            knownSum += roll;
        }

        // Calculate the sum required for the missing rolls
        int missingSum = totalSum - knownSum;

        // Check if it's possible to distribute the missingSum among n rolls
        if (missingSum < n || missingSum > 6 * n) {
            return new int[0];  // Return an empty array if it's impossible
        }

        // Create the result array to store the missing rolls
        int[] result = new int[n];

        // Distribute the missingSum across the n rolls
        for (int i = 0; i < n; i++) {
            // Assign each roll the minimum value of either 6 or the remaining missingSum - (n - i - 1)
            result[i] = Math.Min(6, missingSum - (n - i - 1));
            missingSum -= result[i];
        }

        return result;
    }
}