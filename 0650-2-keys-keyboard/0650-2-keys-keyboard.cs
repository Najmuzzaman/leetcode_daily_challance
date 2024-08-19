public class Solution {
    
    static void SieveOfEratosthenes(int maxN, int[] prime)
    {
        for (int i = 2; i <= maxN; i++)
        {
            prime[i] = i; // Initially assume each number is its own smallest prime factor
        }

        // Sieve to fill SPF array
        for (int i = 2; i * i <= maxN; i++)
        {
            if (prime[i] == i) // i is a prime number
            {
                for (int j = i * i; j <= maxN; j += i)
                {
                    if (prime[j] == j)
                    {
                        prime[j] = i; // Set the smallest prime factor for j
                    }
                }
            }
        }
    }
    
    public int MinSteps(int n) 
    {
        int maxN = n;
        int[] dp = new int[maxN + 1];
        int[] spf = new int[maxN + 1]; // Smallest prime factor (SPF) array

        // Call the sieve function to fill the SPF array
        SieveOfEratosthenes(maxN, spf);

        dp[1] = 0; // Base case: 1 'A' requires 0 operations

        for (int i = 2; i <= maxN; i++)
        {
            if (spf[i] == i)
            {
                // If i is prime, minimum operations are i (1 Copy All + i-1 Paste)
                dp[i] = i;
            }
            else
            {
                // Use the smallest prime factor to compute minimum operations
                int factor = spf[i];
                dp[i] = dp[i / factor] + factor;
            }
        }
        return dp[n];
    }
}