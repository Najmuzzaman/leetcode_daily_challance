public class AllOne 
{
    private Dictionary<string, int> count;
    private SortedSet<(int, string)> se;
    public AllOne()
    {
        count = new Dictionary<string, int>();
        se = new SortedSet<(int, string)>();
    }
    public void Inc(string key)
    {
        int n = count.ContainsKey(key) ? count[key] : 0;
        count[key] = n + 1;
        if (n > 0)
        {
            se.Remove((n, key));
        }
        se.Add((n + 1, key)); 
    }

    public void Dec(string key)
    {
        if (!count.ContainsKey(key)) return;

        int n = count[key];
        se.Remove((n, key));

        if (n - 1 > 0)
        {
            count[key] = n - 1;
            se.Add((n - 1, key));
        }
        else
        {
            count.Remove(key);
        }
    }

    public string GetMaxKey()
    {
        if (se.Count > 0)
        {
            return se.Max.Item2;
        }
        return "";
    }

    public string GetMinKey()
    {
        if (se.Count > 0)
        {
            return se.Min.Item2;
        }
        return "";
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */