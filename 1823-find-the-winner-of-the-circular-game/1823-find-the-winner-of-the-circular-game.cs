public class Solution {
    public int FindTheWinner(int n, int k) {
        List<int> v=new List<int>();
        for(int i=1;i<=n;i++){
            v.Add(i);
        }
        int index=0;
        while(v.Count > 1) {
            index = (index + k - 1) % v.Count;
            v.RemoveAt(index);
        }
        return v[0];
    }
}