public class Solution {
    public int TotalFruit(int[] fruits) {
        Dictionary<int, int> basket = new Dictionary<int, int>();
        int ans = 0;
        int start = 0;

        for (int end = 0; end < fruits.Length; end++) {
            int fruit = fruits[end];
            if (!basket.ContainsKey(fruit))
                basket[fruit] = 0;
            basket[fruit]++;

            while (basket.Count > 2) {
                int startFruit = fruits[start];
                basket[startFruit]--;
                if (basket[startFruit] == 0) {
                    basket.Remove(startFruit);
                }
                start++;
            }

            ans = Math.Max(ans, end - start + 1);
        }

        return ans;
    }
}