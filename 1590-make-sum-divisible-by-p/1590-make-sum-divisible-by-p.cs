public class Solution {
    public int MinSubarray(int[] nums, int p) {
        int n=nums.Length;
        long Sum = nums.Sum(i => (long)i);
        long r = (Sum % p);
        if (r == 0)
        {
            return 0;
        }
        Dictionary<long, int> PreMod = new Dictionary<long, int>();
        PreMod[0] = -1;
        long PreSum = 0;
        int Ans = n;
        for (int i = 0; i <n; i++)
        {
            PreSum += nums[i];
            long mod = (PreSum % p);            
            long Target = (mod - r + p) % p;
            if (PreMod.ContainsKey(Target))
            {
                int CurLen = i - PreMod[Target];
                Ans = Math.Min(Ans, CurLen);
            }
            PreMod[mod] = i;
        }
        return Ans == n ? -1 : Ans;
    }
}