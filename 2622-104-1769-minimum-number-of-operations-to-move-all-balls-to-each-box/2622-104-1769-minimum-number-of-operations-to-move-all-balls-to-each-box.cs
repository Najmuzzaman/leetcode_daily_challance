public class Solution {
    public int[] MinOperations(string boxes) {
        int l = 0, r = 0;
        int tl = 0, tr = 0;
        int n = boxes.Length;
        int[] ans = new int[n];
        
        for (int i = 0; i < n; i++) {
            if (boxes[i] == '1') {
                tr += i;
                r++;
            }
        }

        for (int i = 0; i < n; i++) {
            ans[i]=tr + tl;
            if (boxes[i] == '1') {
                r--;
                l++;
            }
            tl += l;
            tr -= r;
        }

        return ans;
    }
}