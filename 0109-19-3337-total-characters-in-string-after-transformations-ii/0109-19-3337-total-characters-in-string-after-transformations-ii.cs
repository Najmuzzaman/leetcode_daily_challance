public class Solution {
    public int LengthAfterTransformations(string s, int t, IList<int> nums) {
       const int MOD = 1_000_000_007;
        const int SIZE = 26;

        // Initial character frequencies
        long[] charFrequencies = new long[SIZE];
        foreach (char c in s)
        {
            charFrequencies[c - 'a']++;
        }

        // Construct the transformation matrix
        long[,] transformationMatrix = new long[SIZE, SIZE];
        for (int from = 0; from < SIZE; from++)
        {
            int toStart = (from + 1) % SIZE;
            for (int i = 0; i < nums[from]; i++)
            {
                transformationMatrix[from, (toStart + i) % SIZE] = 1;
            }
        }

        // Apply matrix exponentiation
        long[,] poweredMatrix = MultiMod(transformationMatrix, t, SIZE, MOD);

        // Multiply initial frequencies with the result matrix
        long total = 0;
        for (int col = 0; col < SIZE; col++)
        {
            for (int row = 0; row < SIZE; row++)
            {
                total = (total + charFrequencies[row] * poweredMatrix[row, col]) % MOD;
            }
        }

        return (int)total;
    }

    private long[,] MultiMod(long[,] matrix, int exponent, int size, int mod)
    {
        long[,] result = new long[size, size];
        for (int i = 0; i < size; i++)
        {
            result[i, i] = 1;
        }

        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                result = MatrixMultiply(result, matrix, size, mod);
            }
            matrix = MatrixMultiply(matrix, matrix, size, mod);
            exponent >>= 1;
        }

        return result;
    }

    private long[,] MatrixMultiply(long[,] a, long[,] b, int size, int mod)
    {
        long[,] product = new long[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                long sum = 0;
                for (int k = 0; k < size; k++)
                {
                    sum = (sum + a[i, k] * b[k, j]) % mod;
                }
                product[i, j] = sum;
            }
        }
        return product;
    }
}