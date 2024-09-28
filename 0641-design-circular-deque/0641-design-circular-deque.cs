public class MyCircularDeque {
    int[] deque;
    int size = 0;
    int current_ind = 0;
    public MyCircularDeque(int k)
    {
        deque = new int[k];
        current_ind = 0;
        size =k;
    }
    public bool InsertFront(int value)
    {
        if (current_ind + 1 > size)
            return false;
        else
        {
            for (int i = current_ind; i > 0; i--)
                deque[i] = deque[i-1];
            deque[0] = value;
            current_ind++;
            return true;
        }
    }

    public bool InsertLast(int value)
    {
        if (current_ind + 1 > size)
            return false;
        else
        {
            deque[current_ind++] = value;
            return true;
        }
    }

    public bool DeleteFront()
    {
        if (current_ind == 0)
            return false;
        else
        {
            for (int i = 1; i < current_ind; i++)
                deque[i - 1] = deque[i];
            current_ind--;
            return true;
        }
    }

    public bool DeleteLast()
    {

        if (current_ind == 0)
            return false;
        else
        {
            current_ind--;
            return true;
        }
    }

    public int GetFront()
    {
         if (current_ind == 0)
             return -1;
         else
             return deque[0];
    }

    public int GetRear()
    {
         if (current_ind == 0) 
             return -1;
         else
             return deque[current_ind-1];
    }

    public bool IsEmpty()
    {
        return (current_ind == 0);
    }

    public bool IsFull()
    {
        return current_ind == size;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */