public class Solution {
    public long MinDamage(int power, int[] damage, int[] health) {
        int n = damage.Length;
        var enemies = new List<(int index, double efficiency)>(n);

        // Calculate efficiency as damage per total time to defeat
        for (int i = 0; i < n; ++i)
        {
            enemies.Add((i, (double)damage[i] / ((health[i] + power - 1) / power)));
        }

        // Sort by efficiency (higher is better)
        enemies.Sort((a, b) => b.efficiency.CompareTo(a.efficiency));

        long totalDamage = 0;
        long elapsedTime = 0;

        // Calculate total damage by processing the most efficient enemies first
        foreach (var enemy in enemies)
        {
            int idx = enemy.index;
            long timeToDefeat = (health[idx] + power - 1) / power;
            totalDamage += damage[idx] * (elapsedTime + timeToDefeat);
            elapsedTime += timeToDefeat;
        }

        return totalDamage;
    }
}