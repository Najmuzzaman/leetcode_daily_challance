using System;
using System.Collections.Generic;

class Solution
{
    static long mod = 1000000007L;
    static int[] divisibleByNearestPrime = new int[100001];
    static bool[] isPrime = new bool[100001];
    static List<int> primes;

    static Solution()
    {
        for (int i = 0; i < 100001; i++) divisibleByNearestPrime[i] = i;
        primes = new List<int>();
        for (int i = 2; i * i < 100001; i++)
        {
            if (!isPrime[i])
            {
                divisibleByNearestPrime[i] = i;
                for (int j = i * i; j < 100001; j += i)
                {
                    isPrime[j] = true;
                    divisibleByNearestPrime[j] = i;
                }
            }
        }

        for (int i = 2; i < 100001; i++)
        {
            if (!isPrime[i]) primes.Add(i);
        }
    }

    static int PrimeMultiples(int n)
    {
        int count = 0;
        while (n != 1)
        {
            int factor = divisibleByNearestPrime[n];
            count++;
            while (n % factor == 0) n /= factor;
        }
        return count;
    }

    public int MaximumScore(IList<int> nums, int k)
    {
        int n = nums.Count;
        long remainingK = k;
        long[] primeMultiplesArr = new long[n];
        int[] calculatedPrev = new int[100001];

        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            if (calculatedPrev[num] == 0)
            {
                calculatedPrev[num] = PrimeMultiples(num);
            }
            primeMultiplesArr[i] = calculatedPrev[num];
        }

        long[] monotonicArray = new long[n];
        long[] monotonicArray2 = new long[n];
        Stack<long[]> st = new Stack<long[]>();

        for (int i = n - 1; i >= 0; i--)
        {
            while (st.Count > 0 && st.Peek()[0] <= primeMultiplesArr[i])
            {
                st.Pop();
            }
            monotonicArray[i] = (st.Count == 0) ? n - i : st.Peek()[1] - i;
            st.Push(new long[] { primeMultiplesArr[i], i });
        }

        st.Clear();
        for (int i = 0; i < n; i++)
        {
            while (st.Count > 0 && st.Peek()[0] < primeMultiplesArr[i])
            {
                st.Pop();
            }
            monotonicArray2[i] = (st.Count == 0) ? i : i - st.Peek()[1] - 1;
            st.Push(new long[] { primeMultiplesArr[i], i });
        }

        for (int i = 0; i < n; i++)
            monotonicArray[i] += monotonicArray2[i] * monotonicArray[i];

        long[][] arr = new long[n][];
        for (int i = 0; i < n; i++)
        {
            arr[i] = new long[] { nums[i], monotonicArray[i] };
        }

        Array.Sort(arr, (a, b) => b[0].CompareTo(a[0]));

        long ans = 1L;
        for (int i = 0; i < n; i++)
        {
            long data = arr[i][0], times = arr[i][1];
            if (times <= remainingK)
            {
                ans = (ans * PowMod(data, times, mod)) % mod;
                remainingK -= times;
            }
            else
            {
                ans = (ans * PowMod(data, remainingK, mod)) % mod;
                break;
            }
        }
        return (int)ans;
    }

    static long PowMod(long baseVal, long exp, long mod)
    {
        long ans = 1;
        long power = baseVal % mod;
        while (exp > 0)
        {
            if ((exp & 1) == 1) ans = (ans * power) % mod;
            exp >>= 1;
            power = (power * power) % mod;
        }
        return ans;
    }
}