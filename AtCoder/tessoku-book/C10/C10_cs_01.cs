// https://atcoder.jp/contests/tessoku-book/submissions/38281457
using System;
using System.Collections.Generic;

internal class Program
{
    private const long Mod = 1000000007;

    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        long w = long.Parse(strs[0]);

        Console.WriteLine((12 * Power(7, w - 1, Mod)) % Mod);
    }

    private static long Power(long a, long n, long m)
    {
        long p = 1;
        long aa = a;

        while (n > 0)
        {
            if ((n & 1) != 0)
            {
                p = (p * aa) % m;
            }
            aa = (aa * aa) % m;
            n >>= 1;
        }

        return p;
    }
}
