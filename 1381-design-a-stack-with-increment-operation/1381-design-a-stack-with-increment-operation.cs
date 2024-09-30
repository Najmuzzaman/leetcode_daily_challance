public class CustomStack {
    int[] st;
    int Size;
    int Cur;
    public CustomStack(int maxSize) {
        st=new int[maxSize];
        Size=maxSize;
        Cur=0;
    }
    
    public void Push(int x) {
        if(Cur<Size)
        {
            st[Cur++]=x;
        }
    }
    
    public int Pop() {
        if(Cur==0)
        {
            return -1;
        }
        else
        {
            int x=st[Cur-1];
            Cur--;
            return x;
        }
    }
    
    public void Increment(int k, int val) {
       for(int i=0;i<Size && i<k;i++)
           st[i]+=val;
    }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * obj.Increment(k,val);
 */