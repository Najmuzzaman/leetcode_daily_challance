public class Solution {
    public int SmallestChair(int[][] times, int targetFriend) {
        SortedList<int, List<Tuple<int, int>>> events =new SortedList<int, List<Tuple<int, int>>>();
        for (int i = 0; i < times.Length; i++)
        {
            if(!events.ContainsKey(times[i][0]))
                events[times[i][0]] = new List<Tuple<int, int>>();
            if(!events.ContainsKey(times[i][1]))
                events[times[i][1]] = new List<Tuple<int, int>>();

            events[times[i][0]].Add(Tuple.Create(i, 0));
            events[times[i][1]].Add(Tuple.Create(i, 1));
        }
        Dictionary<int, int> chair = new Dictionary<int, int>();
        List<int> freeChairs = new List<int>();
        int nextChair = 0;

        foreach (var e in events)
        {
            int time = e.Key;
            e.Value.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            foreach (var tup in e.Value)
            {
                int friend = tup.Item1;
                int type = tup.Item2;

                if (type == 0)
                {
                    int assignedChair;

                    if (freeChairs.Count > 0)
                    {
                        assignedChair = freeChairs.Min();
                        freeChairs.Remove(assignedChair);
                    }
                    else
                    {
                        assignedChair = nextChair;
                        nextChair++;
                    }

                    chair[friend] = assignedChair;

                    if (friend == targetFriend)
                        return assignedChair;
                }
                else
                {
                    int VacentChair = chair[friend];
                    freeChairs.Add(VacentChair);
                }
            }
        }

        return -1;
    }
}