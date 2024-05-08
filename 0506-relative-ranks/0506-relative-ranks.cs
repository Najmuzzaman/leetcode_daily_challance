public class Solution {
    public string[] FindRelativeRanks(int[] score) {
        int n = score.Length;
        string[] ans = new string[n];
        
        // Find the maximum score
        int maxScore = int.MinValue;
        foreach (int s in score) {
            maxScore = Math.Max(maxScore, s);
        }
        
        // Create an array to store indices of scores
        int[] index = new int[maxScore + 1];
        for (int i = 0; i < n; i++) {
            index[score[i]] = i + 1;
        }
        
        // Assign ranks
        int rank = 1;
        for (int i = maxScore; i >= 0; i--) {
            if (index[i] != 0) {
                if (rank == 1)
                    ans[index[i] - 1] = "Gold Medal";
                else if (rank == 2)
                    ans[index[i] - 1] = "Silver Medal";
                else if (rank == 3)
                    ans[index[i] - 1] = "Bronze Medal";
                else
                    ans[index[i] - 1] = rank.ToString();
                rank++;
            }
        }
        
        return ans;
    }
}