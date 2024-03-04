public class Solution {
    public int BagOfTokensScore(int[] tokens, int power) {
        Array.Sort(tokens);
        int score = 0;
        int maxScore = 0;
        int left = 0;
        int right = tokens.Length - 1;

        while (left <= right) {
            if (power >= tokens[left]) {
                power -= tokens[left];
                left++;
                score++;
                maxScore = Math.Max(maxScore, score);
            } else if (score > 0) {
                power += tokens[right];
                right--;
                score--;
            } else {
                break;
            }
        }

        return maxScore;
    }
}