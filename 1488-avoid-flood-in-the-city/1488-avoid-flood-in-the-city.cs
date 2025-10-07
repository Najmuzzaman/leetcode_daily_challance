public class Solution {
    public int[] AvoidFlood(int[] rains) {
        var res = new int[rains.Length];
        var slots = new List<int>();
        var lakes = new Dictionary<int, int>();

        for(int i = 0; i < rains.Length; i++)
        {
            if (rains[i] == 0)
                slots.Add(i);
            else
            {
                if(lakes.ContainsKey(rains[i]))
                {
                    var idx = slots.BinarySearch(lakes[rains[i]]);
                    if (idx < 0)
                        idx = ~idx;

                    if (idx == slots.Count)
                        return [];

                    res[slots[idx]] = rains[i];
                    slots.RemoveAt(idx);
                }

                res[i] = -1;
                lakes[rains[i]] = i;
            }
        }

        int pos = 0;
        foreach(var kv in lakes)
        {
            if (pos == slots.Count)
                break;

            res[slots[pos++]] = kv.Key;
        }
        while (pos < slots.Count)
            res[slots[pos++]] = 1;

        return res;
    }
}