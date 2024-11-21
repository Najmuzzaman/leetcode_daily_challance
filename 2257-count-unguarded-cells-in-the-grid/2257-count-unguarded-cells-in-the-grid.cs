public class Solution {
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls) {
        var blocked = new HashSet<(int, int)>();
        var guarded = new HashSet<(int, int)>();

        // Mark guards and walls as blocked
        foreach (var guard in guards) 
            blocked.Add((guard[0], guard[1]));
        foreach (var wall in walls) 
            blocked.Add((wall[0], wall[1]));

        // Directions for movement (N, E, S, W)
        int[][] directions = new int[][] {
            new int[] {-1, 0}, // North
            new int[] {0, 1},  // East
            new int[] {1, 0},  // South
            new int[] {0, -1}  // West
        };

        // Mark all cells visible by guards
        foreach (var guard in guards) {
            foreach (var dir in directions) {
                int x = guard[0], y = guard[1];
                while (true) {
                    x += dir[0];
                    y += dir[1];
                    if (x < 0 || y < 0 || x >= m || y >= n || blocked.Contains((x, y)))
                        break;
                    guarded.Add((x, y));
                }
            }
        }

        // Count unguarded cells
        int unguardedCount = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (!blocked.Contains((i, j)) && !guarded.Contains((i, j))) {
                    unguardedCount++;
                }
            }
        }

        return unguardedCount;
    }
}