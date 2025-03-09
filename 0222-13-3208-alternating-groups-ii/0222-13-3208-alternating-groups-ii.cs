public class Solution {
    public int NumberOfAlternatingGroups(int[] colors, int k) {
        int cnt=1;
        int n=colors.Length;
        int ans=0;
        for(int i=0;i<n+k-2;i++){
            if(colors[i%n]!=colors[(i+1)%n]){
                cnt++;
                if(cnt>=k){
                    ans++;
                }
            }else{
                cnt=1;
            }
        }
        return ans;
    }
}