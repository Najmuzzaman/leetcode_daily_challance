public class MyCalendarTwo {
    public class Event
    {
        public int Start { get; }
        public int End { get; }

        public Event(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
    private List<Event> overLapBookings;
    private List<Event> bookings;
    public MyCalendarTwo() {
        overLapBookings = new List<Event>();
        bookings = new List<Event>();
    }
    
    public bool Book(int start, int end) {
       // Check for triple booking
        foreach (var e in overLapBookings)
        {
            if (IsOverlap(e, start, end))
            {
                return false;  
            }  
        }

        // Update the overlap bookings
        foreach (var e in bookings)
        {
            if (IsOverlap(e, start, end))
            {
                overLapBookings.Add(GetOverlapEvent(e, start, end));
            }    
        }  

        // Add the new booking
        bookings.Add(new Event(start, end));

        return true; 
    }
    
    private bool IsOverlap(Event e, int start, int end)
    {
        return Math.Max(e.Start, start) < Math.Min(e.End, end); 
    }

    private Event GetOverlapEvent(Event e, int start, int end)
    {
        return new Event(Math.Max(e.Start, start), Math.Min(e.End, end));  
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */