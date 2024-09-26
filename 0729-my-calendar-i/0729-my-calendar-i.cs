public class MyCalendar {
    private List<Tuple<int, int>> m;
    public MyCalendar() {
        m = new List<Tuple<int, int>>();
    }
    
    public bool Book(int start, int end) {
        foreach (var booking in m)
        {
            if (start < booking.Item2 && end > booking.Item1)
            {
                return false;
            }
        }
        m.Add(Tuple.Create(start, end));
        return true;
    }
}

