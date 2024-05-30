public class Solution {
    public int CountTriplets(int[] arr) {
        int n = arr.Length;
        int[] prefix=new int[n + 1];

        for (int i = 0; i < n; ++i) {
            prefix[i + 1] = prefix[i] ^ arr[i];
        }

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int k = i + 1; k < n; ++k) {
                if (prefix[i] == prefix[k + 1]) {
                    ans += (k - i);
                }
            }
        }

        return ans;  
    }
}