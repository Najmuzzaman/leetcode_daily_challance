public class Solution {
    public int CountGoodTriplets(int[] arr, int a, int b, int c) {
        int n = arr.Length;
        int count = 0;
        for (int i = 0; i < n - 2; i++)
        {
            int ai = arr[i];
            for (int j = i + 1; j < n - 1; j++)
            {
                int aj = arr[j];
                if (Math.Abs(ai - aj) > a)
                    continue;

                for (int k = j + 1; k < n; k++)
                {
                    int ak = arr[k];
                    int diff_jk = Math.Abs(aj - ak);
                    if (diff_jk > b)
                        continue;

                    if (Math.Abs(ai - ak) <= c)
                        count++;
                }
            }
        }

        return count;
    }
}