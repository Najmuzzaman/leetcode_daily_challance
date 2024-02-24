public class Solution {
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson) {
        HashSet<int> ans = new HashSet<int> { 0, firstPerson };        
        List<List<Tuple<int, int>>> sortedMeetings = new List<List<Tuple<int, int>>>();
        Array.Sort(meetings, (a, b) => a[2].CompareTo(b[2]));
        HashSet<int> seenTime = new HashSet<int>();        
        foreach (var meeting in meetings) {
            if (!seenTime.Contains(meeting[2])) {
                seenTime.Add(meeting[2]);
                sortedMeetings.Add(new List<Tuple<int, int>>());
            }
            sortedMeetings.Last().Add(Tuple.Create(meeting[0], meeting[1]));
        }
        foreach (var meetingGroup in sortedMeetings) {
            HashSet<int> preAns = new HashSet<int>();
            Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
            
            foreach (var pair in meetingGroup) {
                if (!g.ContainsKey(pair.Item1))
                    g[pair.Item1] = new List<int>();
                if (!g.ContainsKey(pair.Item2))
                    g[pair.Item2] = new List<int>();
                
                g[pair.Item1].Add(pair.Item2);
                g[pair.Item2].Add(pair.Item1);
                
                if (ans.Contains(pair.Item1))
                    preAns.Add(pair.Item1);
                if (ans.Contains(pair.Item2))
                    preAns.Add(pair.Item2);
            }
            
            Queue<int> queue = new Queue<int>(preAns);
        
            while (queue.Count > 0) {
                int curr = queue.Dequeue();
                ans.Add(curr);
                foreach (int neigh in g[curr]) {
                    if (!ans.Contains(neigh)) {
                        ans.Add(neigh);
                        queue.Enqueue(neigh);
                    }
                }
            }
        }

        return ans.ToList();
    }
}
