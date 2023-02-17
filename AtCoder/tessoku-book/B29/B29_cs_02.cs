// https://atcoder.jp/contests/tessoku-book/submissions/37097924
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static long[] NList => ReadLine().Split().Select(long.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (a, b) = (c[0], c[1]);
        var mod = 1_000_000_007;
        WriteLine(Mul(a, b, mod));
    }
    static long Mul(long a, long b, int mod)
    {
        if (b == 0) return 1;
        if (b == 1) return a;
        var half = Mul(a, b / 2, mod);
        var res = half * half % mod;
        if (b % 2 == 1) res = res * a % mod;
        return res;
    }
}
