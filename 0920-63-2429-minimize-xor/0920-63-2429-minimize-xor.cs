public class Solution {
    public bool IsSet(int x, int bit) { return (x & (1 << bit)) != 0; }
    public void SetBit(ref int x, int bit) { x |= (1 << bit); }
    public void UnsetBit(ref int x, int bit) { x &= ~(1 << bit); }

    public int MinimizeXor(int num1, int num2) {
        int result = num1;

        int targetSetBitsCount = BitOperations.PopCount((uint)num2);
        int setBitsCount = BitOperations.PopCount((uint)result);
        int currentBit = 0;
        while (setBitsCount < targetSetBitsCount)
        {

            if (!IsSet(result, currentBit))
            {
                SetBit(ref result, currentBit);
                setBitsCount++;
            }
            currentBit++;
        }

        while (setBitsCount > targetSetBitsCount)
        {
            if (IsSet(result, currentBit))
            {
                UnsetBit(ref result, currentBit);
                setBitsCount--;
            }
            currentBit++;
        }

        return result;
    }
}