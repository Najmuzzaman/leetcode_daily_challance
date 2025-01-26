public class Solution {
    public int MaximumInvitations(int[] favorite) {
        int n = favorite.Length;
        int[] inDegree = new int[n];

        // Calculate in-degree for each node
        for (int person = 0; person < n; ++person) {
            inDegree[favorite[person]]++;
        }

        // Topological sorting to remove non-cycle nodes
        Queue<int> queue = new Queue<int>();
        for (int person = 0; person < n; ++person) {
            if (inDegree[person] == 0) {
                queue.Enqueue(person);
            }
        }

        int[] depth = new int[n]; // Depth of each node
        Array.Fill(depth, 1);

        while (queue.Count > 0) {
            int currentNode = queue.Dequeue();
            int nextNode = favorite[currentNode];
            depth[nextNode] = Math.Max(depth[nextNode], depth[currentNode] + 1);
            if (--inDegree[nextNode] == 0) {
                queue.Enqueue(nextNode);
            }
        }

        int longestCycle = 0;
        int twoCycleInvitations = 0;

        // Detect cycles
        for (int person = 0; person < n; ++person) {
            if (inDegree[person] == 0) continue; // Already processed

            int cycleLength = 0;
            int current = person;
            while (inDegree[current] != 0) {
                inDegree[current] = 0; // Mark as visited
                cycleLength++;
                current = favorite[current];
            }

            if (cycleLength == 2) {
                // For 2-cycles, add the depth of both nodes
                twoCycleInvitations += depth[person] + depth[favorite[person]];
            } else {
                longestCycle = Math.Max(longestCycle, cycleLength);
            }
        }

        return Math.Max(longestCycle, twoCycleInvitations);
    }
}