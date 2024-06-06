public class Solution {
     public bool findsucessors(int[] h, int g, int ind, int n) 
     {
        int f = h[ind] + 1;
        h[ind] = -1;
        int c = 1;
        ind += 1;
        while (ind < n && c < g) 
        {
            if (h[ind] == f) 
            {
                f = h[ind] + 1;
                h[ind] = -1;
                c++;
            }
            ind++;
        }
        if (c != g)
            return false;
        else
            return true;
    }
    public bool IsNStraightHand(int[] hand, int groupSize) {
        int n = hand.Length;
        if (n % groupSize != 0)
            return false;
        Array.Sort(hand);        
        for (int i = 0; i < n; i++) {
            if (hand[i] >= 0) {
                if (!findsucessors(hand, groupSize, i, n))
                    return false;
            }
        }
        return true;
    }
}