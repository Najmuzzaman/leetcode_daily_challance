public class Solution {
    public IList<string> ReadBinaryWatch(int turnedOn) {
        if (turnedOn == 0) return new List<string> { "0:00" };
        if (turnedOn >= 9) return new List<string>(); // Optimization: max LEDs are 8

        const int mask = (1 << 6) - 1;
        int q = (1 << turnedOn) - 1;
        int max = q << (10 - turnedOn);
        List<string> ans = new List<string>();

        // Gosper's Hack implementation
        while (q <= max && q > 0)
         {
            int min = q & mask;
            int hour = q >> 6;

            if (hour < 12 && min < 60) {
                ans.Add($"{hour}:{min:D2}");
            }

            // Generate the next permutation of bits
            int r = q & -q;
            int n = q + r;
            // Note: bitwise operations on ints are preferred over division
            q = (((q ^ n) >> 2) / r) | n;
        }

        // The bitwise logic doesn't guarantee sorted order, 
        // though the original JS likely didn't either.
        return ans;
    }
}