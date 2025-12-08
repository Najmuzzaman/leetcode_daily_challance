public class Solution {
    public int CountTriples(int n) {
        int[] squares = new int[n+1];
        int res = 0;

        for(int i=0; i<=n; i++)
            squares[i] = i*i;
        
        HashSet<int> squaresSet = new(squares);
        for(int i=1; i<=n; i++){
            for(int j=i+1; j<=n; j++){
                if(squaresSet.Contains(squares[i] + squares[j])){
                    res += 2;
                }
            }
        }
        return res;
    }
}