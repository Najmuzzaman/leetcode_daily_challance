public class Solution {
    public int MinCost(string colors, int[] neededTime) {
        int ans = 0;
        int n = colors.Length;
        int i = 0;
        int j = 1;

        while(j < n){

            while(j < n && colors[i] == colors[j]){

                int t1 = neededTime[i];
                int t2 = neededTime[j];
                if(t1 < t2){
                    ans += t1;
                    i = j++;
                }
                else{
                    ans += t2;
                    j++;
                }
            }
            i = j++;
        }
        return ans;
    }
}