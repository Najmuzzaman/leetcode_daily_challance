public class Solution {
    public int NumRabbits(int[] answers) {
        int ans = 0;
        Dictionary<int, int> mappa = new Dictionary<int, int>();

        foreach (int i in answers) {
            if (mappa.ContainsKey(i))
                mappa[i]++;
            else
                mappa[i] = 1;
        }

        foreach (var kvp in mappa) {
            int color = kvp.Key;
            int qty = kvp.Value;
            ans += (int)Math.Ceiling((double)qty / (color + 1)) * (color + 1);
        }

        return ans;
    }
}