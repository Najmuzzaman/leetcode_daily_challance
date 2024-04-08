public class Solution {
    public int CountStudents(int[] students, int[] sandwiches) {
        int[] c = new int[2];
        foreach (int s in students)
            c[s]++;

        int r = sandwiches.Length;
        foreach (int s in sandwiches)
        {
            if (c[s] == 0) break;
            if (--r == 0) break;
            c[s]--;
        }
        return r;
    }
}