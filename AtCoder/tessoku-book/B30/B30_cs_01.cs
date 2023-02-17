// https://atcoder.jp/contests/tessoku-book/submissions/36941909
using System;

internal class Program
{
    private const int Mod = 1000000007;
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        long h = long.Parse(strs[0]);
        long w = long.Parse(strs[1]);

        Console.WriteLine(ModCombination(h + w - 2, w - 1, Mod));
    }

    private static long ModCombination(long n, long r, long m)
    {
        long d = (ModFactorial(r, m) * ModFactorial(n - r, m)) % m;

        return ModDivide(ModFactorial(n, m), d, m);
    }

    private static long ModFactorial(long a, long m)
    {
        long f = 1;
        for (long i = a; i >= 2; i--)
        {
            f = (f * i) % m;
        }

        return f;
    }

    private static long ModDivide(long a, long b, long m)
    {
        a = a % m;
        return (a * ModPower(b, m - 2, m)) % m;
    }

    private static long ModPower(long a, long b, long m)
    {
        long p = 1;
        long aa = a;

        for (long i = b; i > 0; i = i >> 1)
        {
            if ((i & 1) > 0)
            {
                p = (p * aa) % m;
            }
            aa = (aa * aa) % m;
        }

        return p;
    }
}
